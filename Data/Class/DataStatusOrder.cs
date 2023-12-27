using Web_Ban_Giay_Asp_Net_Core.Data.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataStatusOrder : IAddData
    {
        public string[] arr_status_order = { "CHỜ XÁC NHẬN", "ĐÃ XÁC NHẬN", "CHỜ LẤY HÀNG", "ĐANG GIAO HÀNG", "ĐÃ GIAO HÀNG", "TRẢ HÀNG", "HỦY ĐƠN HÀNG" };
        public void AddDataToTable(MyDbContext dbContext)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < arr_status_order.Length; i++)
                    {
                        var status_order = new StatusOrder
                        {
                            id_status_order = i + 1,
                            name_status = arr_status_order[i]
                        };
                        dbContext.StatusOrders.Add(status_order);
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
