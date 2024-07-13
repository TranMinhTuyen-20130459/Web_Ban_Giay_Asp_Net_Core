namespace Web_Ban_Giay_Asp_Net_Core.Repository.Class
{
    public class HistoryOrderRepository : IHistoryOrderRepository
    {
        private readonly MyDbContext _dbContext;

        public HistoryOrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy ra danh sách đơn hàng được mua bởi số điện thoại 
        public List<HistoryOrderModel> GetListOrderByPhoneNumber(string phoneNumber, int page, int pageSize)
        {

            if (phoneNumber == null || page <= 0 || pageSize <= 0) { return null; }

            IQueryable<Order> query = _dbContext.Orders.Where(od => od.to_phone == phoneNumber);

            #region Paging
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            var queryResult = query.Select(od => new HistoryOrderModel(od.id_order,
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

        // Lấy ra số lượng đơn hàng được mua bởi số điện thoại
        public int GetOrderCountByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Orders.Where(od => od.to_phone == phoneNumber).Count();
        }

    }
}
