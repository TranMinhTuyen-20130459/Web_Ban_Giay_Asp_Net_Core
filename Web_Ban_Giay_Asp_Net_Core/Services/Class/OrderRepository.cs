namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _dbContext;

        public OrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
         * Thêm đơn hàng vào hệ thống
         */
        public long? CreateOrder(OrderModel orderModel)
        {
            AddressModel addressModel = orderModel.to_address;
            List<OrderDetailModel> orderDetailModels = orderModel.list_order_detail;

            var orderEntity = new Order
            {
                to_name = orderModel.name_customer,
                to_phone = orderModel.phone,
                to_address = addressModel.address,
                to_ward_name = addressModel.ward_name,
                to_district_name = addressModel.district_name,
                to_province_name = addressModel.province_name,
                to_ward_id = addressModel.ward_id,
                to_district_id = addressModel.district_id,
                to_province_id = addressModel.province_id,

                email_customer = orderModel.email_customer,
                note = orderModel.note,

                ship_price = orderModel.ship_price,
                order_value = orderModel.order_value,
                total_price = orderModel.ship_price + orderModel.order_value,

                id_status_order = (int)StatusOrderEnum.CHO_XAC_NHAN,
                id_status_payment = orderModel.payment.id_status_payment,
                id_method_payment = orderModel.payment.id_method_payment
            };

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Thêm thực thể Order vào bảng Orders và lưu thay đổi để lấy ID mới
                    _dbContext.Orders.Add(orderEntity);
                    _dbContext.SaveChanges();

                    long newOrderId = orderEntity.id_order;

                    // Thêm chi tiết đơn hàng và cập nhật số lượng sản phẩm
                    foreach (var orderDetailModel in orderDetailModels)
                    {
                        // Tạo thực thể OrderDetail từ OrderDetailModel
                        var orderDetailEntity = new OrderDetail
                        {
                            id_order = newOrderId,
                            id_product = orderDetailModel.id_product,
                            name_size = orderDetailModel.name_size,
                            quantity = orderDetailModel.quantity,
                            price = orderDetailModel.price
                        };

                        // Thêm thực thể OrderDetail vào bảng OrderDetails
                        _dbContext.OrderDetails.Add(orderDetailEntity);

                        // Cập nhật số lượng sản phẩm trong bảng SizeProducts
                        var sizeProduct = _dbContext.SizeProducts
                            .FirstOrDefault(sp => sp.id_product == orderDetailModel.id_product && sp.name_size == orderDetailModel.name_size);

                        if (sizeProduct != null)
                        {
                            // số lượng sản phẩm đang có trong hệ thống phải >= số lượng sản phẩm đặt mua 
                            if (sizeProduct.quantity_available >= orderDetailModel.quantity)
                            {
                                sizeProduct.quantity_available -= orderDetailModel.quantity;
                            }
                            else
                            {
                                // throw new Exception("So luong san pham dat mua vuot qua so luong san pham dang con trong he thong");

                                transaction.Rollback();
                                return -1;

                            }
                        }
                    }

                    // Lưu thay đổi để hoàn thành giao dịch
                    _dbContext.SaveChanges();
                    transaction.Commit();

                    // Trả về ID của đơn hàng mới
                    return newOrderId;
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return null;
        }

        /*
         * Lấy ra thông tin chi tiết của đơn hàng dựa vào id_order
         */
        public HistoryOrderDetailModel GetOrderDetailByIdOrder(long id_order)
        {
            if (id_order < 1) return null;

            // Tạo câu truy vấn cơ sở để lấy thông tin đơn hàng và thông tin chi tiết đơn hàng đó 
            IQueryable<Order> baseQuery = _dbContext.Orders
                .Include(order => order.list_order_details) // Include thông tin chi tiết đơn hàng
                .ThenInclude(order_detail => order_detail.product) // sau đó lại tiếp tục Include thông tin sản phẩm trong chi tiết đơn hàng
                .ThenInclude(product => product.list_image) // rồi lại tiếp tục Include thông tin ds hình ảnh của sản phẩm
                .Where(od => od.id_order == id_order);

            var queryResult = baseQuery.Select(order => new
            {
                id_order = order.id_order,
                name_customer = order.to_name,
                to_address = order.to_address,
                to_ward = order.to_ward_name,
                to_district = order.to_district_name,
                to_province = order.to_province_name,
                phone = order.to_phone,
                time_order = order.time_order,
                status_order = order.id_status_order,
                list_order_detail = order.list_order_details,
                order_value = order.order_value,
                ship_price = order.ship_price,
                total_price = order.total_price,
                id_status_payment = order.id_status_payment,
                id_method_payment = order.id_method_payment
            }).ToList();

            if (queryResult.Any()) // nếu kết quả truy vấn có phần tử
            {
                // Tạo model từ kết quả truy vấn
                var model = queryResult.Select(order => new HistoryOrderDetailModel
                {
                    infor_order = new HistoryOrderModel(order.id_order,
                                                        order.name_customer,
                                                        order.to_address,
                                                        order.to_ward,
                                                        order.to_district,
                                                        order.to_province,
                                                        order.phone,
                                                        order.time_order,
                                                        order.status_order,
                                                        new PaymentModel_Ver2(order.id_status_payment, order.id_method_payment)
                                                        ),

                    order_details = order.list_order_detail
                        .Select(order_detail => new OrderDetailModel_Ver2
                        {

                            id_product = order_detail.id_product,
                            name_product = order_detail.product.name_product,

                            list_image_product = order_detail.product.list_image.Select(img => new ImageProductModel
                            {
                                id_image = img.id_image,
                                path_image = img.path
                            }).ToList(),

                            name_size = order_detail.name_size,
                            quantity = order_detail.quantity,
                            price = order_detail.price

                        }).ToList(),

                    order_value = order.order_value,
                    ship_price = order.ship_price,
                    total_price = order.total_price

                }).SingleOrDefault();

                return model;
            }

            return null;
        }

        /*
         * Lấy ra danh sách tất cả đơn hàng đang có trong hệ thống 
         * 
         * => có phân trang kết quả API trả về 
         */
        public List<HistoryOrderModel> GetAllOrder(int page, int pageSize)
        {
            IQueryable<Order> query = _dbContext.Orders
                                                .Skip((page - 1) * pageSize)
                                                .Take(pageSize);

            var queryResult = query.Select(od => new HistoryOrderModel(od.id_order,
                                                                        od.to_name,
                                                                        od.to_address,
                                                                        od.to_ward_name,
                                                                        od.to_district_name,
                                                                        od.to_province_name,
                                                                        od.to_phone,
                                                                        od.time_order,
                                                                        od.id_status_order,
                                                                        new PaymentModel_Ver2(od.id_status_payment, od.id_method_payment))
                                           ).ToList();

            return queryResult;
        }

        /*
         * Lấy ra số lượng đơn hàng đang có trong hệ thống 
         * 
         * => dùng để phân trang kết quả API trả về
         */
        public long GetCountAllOrder()
        {
            return _dbContext.Orders.Count();
        }

        /*
         * Lấy ra danh sách đơn hàng theo trạng thái 
         * 
         * VD:
         * + Lấy ra danh sách các đơn hàng có trạng thái CHỜ XÁC NHẬN 
         * + Lấy ra danh sách đơn hàng có trạng thái ĐANG GIAO HÀNG 
         */
        public List<HistoryOrderModel> GetListOrderByStatus(int id_status_order, int page, int pageSize)
        {
            IQueryable<Order> query = _dbContext.Orders
                                                .Where(order => order.id_status_order == id_status_order)
                                                .Skip((page - 1) * pageSize)
                                                .Take(pageSize);

            var queryResult = query.Select(od => new HistoryOrderModel(
                                                od.id_order,
                                                od.to_name,
                                                od.to_address,
                                                od.to_ward_name,
                                                od.to_district_name,
                                                od.to_province_name,
                                                od.to_phone,
                                                od.time_order,
                                                od.id_status_order,
                                                new PaymentModel_Ver2(od.id_status_payment, od.id_method_payment)
                                                )).ToList();

            return queryResult;
        }

        /*
         * Lấy ra số lượng đơn hàng theo trạng thái 
         * 
         * VD:
         * + Lấy ra số lượng đơn hàng đang có trạng thái là CHỜ XÁC NHẬN
         * + Lấy ra số lượng đơn hàng đang có trạng thái ĐANG GIAO HÀNG 
         * 
         * => dùng để phân trang kết quả API trả về
         */
        public long CountOrdersByStatus(int id_status_order)
        {
            var query = _dbContext.Orders.Where(order => order.id_status_order == id_status_order);

            return query.Count();
        }
    }
}
