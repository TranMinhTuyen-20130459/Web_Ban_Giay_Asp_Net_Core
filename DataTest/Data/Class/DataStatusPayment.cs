namespace DataTest.Data.Class
{
    public class DataStatusPayment : IAddData
    {
        public string[] arr_status_payment = { "CHỜ THANH TOÁN", "ĐÃ THANH TOÁN" };
        public void AddDataToTable(MyDbContext dbContext)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < arr_status_payment.Length; i++)
                    {
                        var status_payment = new StatusPayment
                        {
                            id_status_payment = i + 1,
                            name_status = arr_status_payment[i]
                        };
                        dbContext.StatusPayments.Add(status_payment);
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
