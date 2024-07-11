using DataTest.Config;
using DataTest.Data.Class;
using System.Diagnostics;

namespace DataTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var configuration = ConfigUtils.GetConfiguration();
            MyDbContext dbContext = new MyDbContext(configuration);

            try
            {
                // AddData.AddDataToTable_First(dbContext);
                // AddData.AddDataToTable_Second(dbContext);
                // AddData.AddDataToTable_Three(dbContext);
                AddData.AddDataToTable_Four(dbContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dbContext.Dispose();
                watch.Stop();
                Console.WriteLine("Total time: " + watch.Elapsed.TotalMinutes + "minute");
            }

            Console.ReadKey();
        }
    }
}
