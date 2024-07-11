using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataSize : IAddData
    {
        public string[] arr_size = { "36", "37", "38", "39", "40", "41", "42", "43", "44" };
        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in arr_size)
                    {
                        var size = new Size { name_size = item };
                        dbContext.Sizes.Add(size);
                        dbContext.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);
                }
            }
            watch.Stop();
            TimeSpan time = watch.Elapsed;
            Console.WriteLine("Excute time: " + time.TotalSeconds + " s");
        }
    }
}
