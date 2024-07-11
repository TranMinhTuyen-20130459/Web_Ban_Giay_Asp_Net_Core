using System.Diagnostics;

namespace DataTest.Data.Class
{
    public class DataProductShoes : IAddData
    {
        public static string[] arr_name_products_nike = {"NIKE PEGASUS 40", "NIKE RUN SWIFT 3", "NIKE AIR MAX 90 SE",
            "NIKE AIR FORCE 1 LV8", "NIKE AIR MAX 270 SE", "NIKE GAMMA FORCE",
            "NIKE AIR FORCE 1 '07", "AIR FORCE 1", "NIKE RUN SWIFT 3",
            "NIKE AIR MAX 90", "NIKE REVOLUTION 6 NN", "NIKE PEGASUS 40",
            "NIKE STAR RUNNER 3", "NIKE QUEST 4", "NIKE AIR MAX 97"};

        public static string[] arr_name_products_adidas = {"ADIDAS GALAXY 6 W", "ADIDAS ZNCHILL LIGHTMOTION", "ADIDAS RUN FALCON 3.0",
            "ADIDAS ULTRABOOST OG", "ADIDAS ULTRABOOST 20", "ADIDAS FORUM LOW CL",
            "ADIDAS ULTRA 4D", "ADIDAS NMD R1 REFINED", "ADIDAS ULTRA 4D",
            "ADIDAS ZNCHILL LIGHTMOTION", "ADIDAS ULTRA4D SUN DEVILS", "SN1997 X MARIMEKKO",
            "ADIDAS GRADAS CLOUD WHITE", "ADIDAS PUREMOTION", "ADIDAS GRAND COURT"};

        public static string[] arr_name_products_jordan = {"JORDAN 1 LOW", "JORDAN 1 LOW LIGHT SMOKE GREY", "JORDAN 1 HI OG",
            "AIR JORDAN 1 HI OG", "JORDAN 1 HI ZOOM CMFT", "AIR JORDAN 1 MID",
            "JORDAN 1 BLACK WHITE RED", "NIKE AIR JORDAN 4 PINE GREEN", "AIR JORDAN 1 HI CHICAGO",
            "JORDAN 1 LOW CRAFT", "JORDAN 1 HI RETRO 85", "AIR JORDAN 1 LOW",
            "AIR JORDAN 1 LOW", "AIR JORDAN 1 LOW SE", "AIR JORDAN 1 LOW"};

        public static List<string[]> list_arr_name_product = new List<string[]>();

        static DataProductShoes()
        {
            list_arr_name_product.Add(arr_name_products_nike);
            list_arr_name_product.Add(arr_name_products_adidas);
            list_arr_name_product.Add(arr_name_products_jordan);
        }

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Random random = new Random();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Tạo đối tượng typeProduct với chỉ số id_type tương ứng (giả sử id_type = 1)
                    var typeProduct = new TypeProduct { id_type = 1 }; // Loại: GIÀY

                    // Gắn đối tượng typeProduct đã tạo vào dbContext mà không thay đổi trạng thái
                    dbContext.TypeProducts.Attach(typeProduct);

                    // Tạo đối tượng Brand trước khi bắt đầu lặp
                    for (int i = 0; i < list_arr_name_product.Count; i++)
                    {
                        var brand = new Brand { id_brand = i + 1 }; // Brand: 1 - "NIKE", 2 - "ADIDAS", 3 - "JORDAN"
                        dbContext.Brands.Attach(brand);    // Gắn đối tượng brand đã tạo vào dbContext mà không thay đổi trạng thái
                    }

                    for (int k = 0; k < 100; k++)
                    {
                        for (int i = 0; i < list_arr_name_product.Count; i++)
                        {
                            var arr_name_product = list_arr_name_product[i];
                            var brand = dbContext.Brands.Local.FirstOrDefault(b => b.id_brand == i + 1);

                            foreach (var name_product in arr_name_product)
                            {
                                var product = new Product
                                {
                                    name_product = name_product,
                                    star_review = random.Next(4, 6), // random ra số 4 or 5
                                    id_status_product = random.Next(1, 8),
                                    brand = brand,
                                    type_product = typeProduct,
                                    listed_price = random.Next(0, (int)(15 * Math.Pow(10, 6))),
                                    promotional_price = random.Next(0, (int)(15 * Math.Pow(10, 6))),
                                    id_sex = (byte)random.Next(1, 3)
                                };
                                dbContext.Products.Add(product);
                                Console.WriteLine(".................");
                            }
                        }
                    }
                    dbContext.SaveChanges(); // Lưu thay đổi sau mỗi lần thêm dữ liệu vào cơ sở dữ liệu
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
