using Web_Ban_Giay_Asp_Net_Core.Data.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataMethodPayment : IAddData
    {
        public string[] arr_method_payment = { "Cash", "ZaloPay", "PayPal" };
        public void AddDataToTable(MyDbContext dbContext)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < arr_method_payment.Length; i++)
                    {
                        var method_payment = new MethodPayment
                        {
                            id_method_payment = i + 1,
                            name_method = arr_method_payment[i]
                        };
                        dbContext.MethodPayments.Add(method_payment);
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
