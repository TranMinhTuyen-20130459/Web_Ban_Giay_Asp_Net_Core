using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataProductSportsWear : IAddData
    {
        public static string[] arr_name_products_nike = { "BỘ QUẦN ÁO PSG 2023 2024 ĐEN VÀNG – HÀNG THAILAND",
            "BỘ QUẦN ÁO BÓNG ĐÁ INTER MIAMI 2023 2024 HỒNG – HÀNG THAILAND",
            "BỘ QUẦN ÁO LIVERPOOL 2023 2024 SÂN NHÀ – HÀNG THAILAND",
            "BỘ QUẦN ÁO BÓNG ĐÁ ARSENAL 2022 2023 VÀNG – VẢI MÈ LỤC GIÁC",
            "BỘ QUẦN ÁO BÓNG ĐÁ ARSENAL 2022 2023 TÍM – VẢI MÈ LỤC GIÁC"
            };

        public static string[] arr_name_products_adidas = { "BỘ QUẦN ÁO BÓNG ĐÁ TUYỂN ANH WORLD CUP 2022 SÂN KHÁCH",
        "BỘ QUẦN ÁO BÓNG ĐÁ TUYỂN ANH WORLD CUP 2022 SÂN NHÀ",
        "BỘ QUẦN ÁO BÓNG ĐÁ TUYỂN ANH OLYMPIC TOKYO 2021",
        "BỘ QUẦN ÁO BÓNG ĐÁ TUYỂN ANH EURO 2004 SÂN NHÀ",
        "BỘ QUẦN ÁO BÓNG ĐÁ TRAINING TUYỂN ANH EURO 2021"};

        public static string[] arr_name_products_jordan = { "BỘ QUẦN ÁO BÓNG ĐÁ ARGENTINA 2023 2024 ĐEN XANH – THUN LẠNH CAO CẤP",
        "BỘ QUẦN ÁO THỂ THAO WIKA POLO ALPHA TRẮNG – VẢI POLYESTER",
        "BỘ QUẦN ÁO THỂ THAO WIKA POLO ALPHA XANH NGỌC – VẢI POLYESTER",
        "BỘ QUẦN ÁO THỂ THAO POLO LACOSTE MẪU 4 XANH DƯƠNG",
        "BỘ QUẦN ÁO THỂ THAO POLO LACOSTE MẪU 1 XANH LÁ"};

        public static List<string[]> list_arr_name_product = new List<string[]>();

        static DataProductSportsWear()
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
                    // Tạo đối tượng typeProduct với chỉ số id_type tương ứng (giả sử id_type = 3)
                    var typeProduct = new TypeProduct { id_type = 3 }; // Loại: ĐỒ THỂ THAO

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

