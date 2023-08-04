using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataTypeProduct : IAddData
    {
        public string[] arr_type_products = { "GIÀY", "DÉP", "PHỤ KIỆN" };

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in arr_type_products)
                    {
                        var typeProduct = new TypeProduct { name_type = item };
                        dbContext.TypeProducts.Add(typeProduct);
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
            TimeSpan elapsedTime = watch.Elapsed;
            Console.WriteLine("Excute time: " + elapsedTime.TotalSeconds + " s");
        }
    }
}
