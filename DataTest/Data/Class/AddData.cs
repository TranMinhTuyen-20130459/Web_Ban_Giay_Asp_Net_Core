namespace DataTest.Data.Class
{
    public class AddData
    {

        public static void AddDataToTable_First(MyDbContext dbContext)
        {
            new DataUser().AddDataToTable(dbContext);

            new DataAdmin().AddDataToTable(dbContext);

            new DataTypeProduct().AddDataToTable(dbContext);

            new DataBrand().AddDataToTable(dbContext);

            new DataSize().AddDataToTable(dbContext);

            new DataPriceRange().AddDataToTable(dbContext);

            new DataStatusOrder().AddDataToTable(dbContext);

            new DataStatusPayment().AddDataToTable(dbContext);

            new DataMethodPayment().AddDataToTable(dbContext);
        }

        public static void AddDataToTable_Second(MyDbContext dbContext)
        {
            new DataProductShoes().AddDataToTable(dbContext);
            new DataImageProductShoes().AddDataToTable(dbContext);
        }

        public static void AddDataToTable_Three(MyDbContext dbContext)
        {
            new DataSizeProduct().AddDataToTable(dbContext);
            new DataOrder().AddDataToTable(dbContext);
        }

        public static void AddDataToTable_Four(MyDbContext dbContext)
        {
            new DataOrderDetail().AddDataToTable(dbContext);
            new DataHistoryPriceProduct().AddDataToTable(dbContext);
        }


    }
}
