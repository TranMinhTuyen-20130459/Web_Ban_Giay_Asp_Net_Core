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

            IQueryable<Order> baseQuery = _dbContext.Orders
                .Include(od => od.list_order_details)
                .ThenInclude(order_detail => order_detail.product) // Include thông tin sản phẩm
                .ThenInclude(product => product.list_image) // Include thông tin list_image của sản phẩm
                .Where(od => od.id_order == id_order);

            var queryResult = baseQuery.Select(od1 => new
            {
                id_order = od1.id_order,
                time_order = od1.time_order,
                status_order = od1.id_status_order,
                list_order_detail = od1.list_order_details,
                order_value = od1.order_value,
                ship_price = od1.ship_price,
                total_price = od1.total_price
            }).ToList();

            if (queryResult.Any()) // nếu danh sách truy vấn có phần tử
            {
                var model = queryResult.Select(od2 => new HistoryOrderDetailModel
                {
                    infor_order = new HistoryOrderModel(od2.id_order, od2.time_order, od2.status_order),

                    list_order_detail = od2.list_order_detail
                        .Select(orderDetail => new OrderDetailModel_Ver2
                        {

                            id_product = orderDetail.id_product,
                            name_product = orderDetail.product.name_product,

                            image_product = orderDetail.product.list_image.Any() ?

                                new ImageProductModel
                                {
                                    id_image = orderDetail.product.list_image.ElementAt(0).id_image,
                                    path_image = orderDetail.product.list_image.ElementAt(0).path
                                }
                                : null,

                            name_size = orderDetail.name_size,
                            quantity = orderDetail.quantity,
                            price = orderDetail.price

                        }).ToList(),

                    order_value = od2.order_value,
                    ship_price = od2.ship_price,
                    total_price = od2.total_price

                }).FirstOrDefault();

                return model;
            }

            return null;
        }

    }
}
