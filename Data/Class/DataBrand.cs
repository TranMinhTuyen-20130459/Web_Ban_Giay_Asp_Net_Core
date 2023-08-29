using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataBrand : IAddData
    {

        public string[] arr_brands = { "NIKE", "ADIDAS", "JORDAN" };

        public void AddDataToTable(MyDbContext dbContext)
        {
            // Khởi tạo Stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var brandName in arr_brands)
                    {
                        var brand = new Brand { name_brand = brandName };
                        dbContext.Brands.Add(brand);

                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("Add data success to table brands");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);
                }
            }
            // Dừng đồng hồ đo thời gian
            stopwatch.Stop();

            // Lấy thời gian thực thi và in ra màn hình
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("Execute time: " + elapsedTime.TotalSeconds + " s");
        }
    }
}
