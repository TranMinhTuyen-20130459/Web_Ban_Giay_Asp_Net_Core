using System.Diagnostics;

namespace DataTest.Data.Class
{
    public class DataAdmin : IAddData
    {
        public string[] arr_email = { "tranminhtuyen@gmail.com", "trannhuthao@gmail.com", "huynhthitham@gmail.com", "phanthian@gmail.com", "nguyentrungkien@gmail.com" };
        public string[] arr_password = { "k46-it-nlu", "k46-it-nlu", "k46-it-nlu", "k46-it-nlu", "k46-it-nlu" };

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < arr_email.Length; i++)
                    {
                        var admin = new Admin
                        {
                            email = arr_email[i],
                            password = arr_password[i]
                        };

                        dbContext.Admins.Add(admin);
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
            Console.WriteLine("Execute time " + watch.Elapsed.TotalSeconds + " s");
        }

        void IAddData.AddDataToTable(MyDbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}
