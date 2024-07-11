using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Data.Util;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataOrderDetail : IAddData
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
                    var list_id_order = DataUtil.GetListIdOrder(dbContext);
                    var list_id_product = DataUtil.GetListIdProduct(dbContext);

                    foreach (var id_order in list_id_order)
                    {

                        // lấy ra ngẫu nhiên từ 1 đến 9 các id_product trong list_id_product
                        var list_id_product_random = Util.FunctionUtil
                            .GetListElementRandom(list_id_product, random.Next(1, 10));

                        foreach (var id_product in list_id_product_random)
                        {
                            var orderDetail = new OrderDetail
                            {
                                id_order = (long)id_order,
                                id_product = (long)id_product,
                                quantity = random.Next(1, 100),
                                price = random.Next(0, (int)(10 * Math.Pow(10, 6)))

                            };
                            dbContext.OrderDetails.Add(orderDetail);
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
