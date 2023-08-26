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

    }
}
