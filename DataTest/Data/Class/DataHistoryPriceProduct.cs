using System.Diagnostics;

namespace DataTest.Data.Class
{
    public class DataHistoryPriceProduct : IAddData
    {
        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var list_id_product = DataUtil.GetListIdProduct(dbContext);
                    foreach (var id_product in list_id_product)
                    {
                        // một product sẽ có từ 3 đến 9 history_price_product
                        int quantity_price = random.Next(3, 10);

                        for (int i = 0; i < quantity_price; i++)
                        {
                            var historyPrice = new HistoryPriceProduct
                            {
                                id_product = (long)id_product,
                                // Phương thức NextDouble() sẽ tạo ra một số dấu phẩy động ngẫu nhiên từ 0.0 đến 1.0
                                listed_price = (decimal)(random.NextDouble() * (10 * Math.Pow(10, 6))),
                                promotional_price = (decimal)(random.NextDouble() * (10 * Math.Pow(10, 6)))
                            };
                            dbContext.HistoryPriceProducts.Add(historyPrice);
                        }
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
            }

            watch.Stop();
            Console.WriteLine("Execute time: " + watch.Elapsed.TotalSeconds + " s");
        }
    }
}
