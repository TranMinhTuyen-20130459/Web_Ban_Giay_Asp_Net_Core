using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataTypeProduct : IAddData
    {
        public string[] arr_type_products = { "GIÀY", "DÉP", "ĐỒ THỂ THAO", "PHỤ KIỆN" };

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < arr_type_products.Length; i++)
                    {
                        var typeProduct = new TypeProduct
                        {
                            id_type = i + 1,
                            name_type = arr_type_products[i]
                        };
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
