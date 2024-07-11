using System.Diagnostics;

namespace DataTest.Data.Class
{
    public class DataPriceRange : IAddData
    {
        public static Dictionary<String, int[]> price_ranges = new Dictionary<String, int[]>();

        static DataPriceRange()
        {
            price_ranges.Add("DƯỚI 3 TRIỆU", new int[] { 0, (int)(3 * Math.Pow(10, 6) - 1) });
            price_ranges.Add("TỪ 3 ĐẾN 5 TRIỆU", new int[] { (int)(3 * Math.Pow(10, 6)), (int)(5 * Math.Pow(10, 6)) });
            price_ranges.Add("TỪ 5 ĐẾN 10 TRIỆU", new int[] { (int)(5 * Math.Pow(10, 6)), (int)(10 * Math.Pow(10, 6)) });
            price_ranges.Add("TỪ 10 ĐẾN 15 TRIỆU", new int[] { (int)(10 * Math.Pow(10, 6)), (int)(15 * Math.Pow(10, 6)) });
            price_ranges.Add("TRÊN 15 TRIỆU", new int[] { (int)(15 * Math.Pow(10, 6)), (int)(1000 * Math.Pow(10, 6)) });
        }

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var price in price_ranges)
                    {
                        var name_price_range = price.Key;
                        var value_price_range = price.Value;

                        var priceRange = new PriceRange
                        {
                            name_price_range = name_price_range,
                            price_start = value_price_range[0],
                            price_end = value_price_range[1]
                        };
                        dbContext.PriceRanges.Add(priceRange);
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);
                }
            }

            watch.Stop();
            Console.WriteLine("Execute time: " + watch.Elapsed.TotalSeconds + " s");
        }
    }
}
