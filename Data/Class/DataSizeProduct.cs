using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Data.Util;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataSizeProduct : IAddData
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
                    var list_name_size = DataUtil.GetListNameSize(dbContext);
                    foreach (var id_product in list_id_product)
                    {
                        foreach (var name_size in list_name_size)
                        {
                            var sizeProduct = new SizeProduct
                            {
                                id_product = (long)id_product,
                                name_size = (string)name_size,
                                quantity_available = random.Next(0, 1000)
                            };
                            dbContext.SizeProducts.Add(sizeProduct);
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
