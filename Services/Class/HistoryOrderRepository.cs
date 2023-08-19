using Microsoft.EntityFrameworkCore;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class HistoryOrderRepository : IHistoryOrderRepository
    {
        private readonly MyDbContext _dbContext;

        public HistoryOrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<HistoryOrderModel> GetListOrderByPhoneNumber(string phoneNumber, int page, int pageSize)
        {

            if (phoneNumber == null || page <= 0 || pageSize <= 0) { return null; }

            IQueryable<Order> baseQuery = _dbContext.Orders.Where(od => od.to_phone == phoneNumber);

            #region Paging
            baseQuery = baseQuery.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            #region Select
            baseQuery = baseQuery.Select(od => new Order
            {
                id_order = od.id_order,
                time_order = od.time_order,
                id_status_order = od.id_status_order,
            });
            #endregion

            var queryResult = baseQuery.ToList();

            if (queryResult.Any()) // nếu danh sách kết quả có phần tử
            {

                // chuyển ds kết quả truy vấn thành ds kết quả dạng model
                var list_history_purchase_model = queryResult.Select(order =>
                                                 new HistoryOrderModel(order.id_order, order.time_order, order.id_status_order)
                                                 ).ToList();

                return list_history_purchase_model;
            }

            return null; // Trả về null nếu danh sách kết quả rỗng
        }

        public int GetOrderCountByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Orders.Where(od => od.to_phone == phoneNumber).Count();
        }

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
                time_order = order.time_order,
                status_order = order.id_status_order,
                list_order_detail = order.list_order_details,
                order_value = order.order_value,
                ship_price = order.ship_price,
                total_price = order.total_price
            }).ToList();

            if (queryResult.Any()) // nếu kết quả truy vấn có phần tử
            {
                // Tạo model từ kết quả truy vấn
                var model = queryResult.Select(order => new HistoryOrderDetailModel
                {
                    infor_order = new HistoryOrderModel(order.id_order, order.time_order, order.status_order),

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

    }
}
