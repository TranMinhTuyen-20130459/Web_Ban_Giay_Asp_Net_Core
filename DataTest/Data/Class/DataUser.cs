using System.Diagnostics;

namespace DataTest.Data.Class
{
    public class DataUser : IAddData
    {

        public string[] arr_email = { "test@gmail.com" };
        public string[] arr_password = { "k46-it-nlu" };

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
                        var user = new User
                        {
                            email = arr_email[i],
                            password = arr_password[i]
                        };

                        dbContext.Users.Add(user);
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
    }
}
