using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataBrand : IAddData
    {

        public string[] arr_brands = { "NIKE", "ADIDAS", "JORDAN" };

        public void AddDataToTable(MyDbContext dbContext)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var brandName in arr_brands)
                    {
                        var brand = new Brand { name_brand = brandName };
                        dbContext.Add(brand);

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
        }
    }
}
