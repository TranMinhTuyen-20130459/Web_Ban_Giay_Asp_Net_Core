using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Data.Util;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataImageProductSportsWear : IAddData
    {
        public static string[] arr_path_img = { "https://cdn.yousport.vn/Media/Products/151022033424313/qabd-khong-logo-riki-namor-2-hong-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022033424313/qabd-khong-logo-riki-namor-tim-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022033424313/qabd-khong-logo-riki-namor-den-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022033424313/qabd-khong-logo-riki-namor-xanh-bich-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022033424313/qabd-khong-logo-riki-namor-xanh-yamaha-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022033424313/qabd-khong-logo-riki-namor-trang-xam-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022034613075/qabd-khong-logo-jp-dragon-trang-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/151022034613075/qabd-khong-logo-jp-dragon-xanh-den-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/220118090426333/qabd-vn-2023-do-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/220118090426333/qabd-vn-2023-trang-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/180520115522347/qabd-phap-2023-trang-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/180520115522347/quan-ao-bong-da-doi-tuyen-quoc-gia-vai-thun-lanh-yousport-xanh-den-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/180520115419419/quan-ao-bong-da-doi-tuyen-quoc-gia-bo-dao-nha-yousport-trang-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/180520115419419/quan-ao-bong-da-doi-tuyen-quoc-gia-bo-dao-nha-yousport-xanh-do-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/160419115852629/qabd-duc-2023-den-do-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/160419115852629/qabd-duc-2023-xanh-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/220922113516254/quan-ao-bong-da-doi-tuyen-quoc-gia-nhat-ban-yousport-xanh-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/170421023252533/qabd-anh-2023-trang-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/131020095741114/qabd-brasil-2023-vang-1_large.jpg",
        "https://cdn.yousport.vn/Media/Products/070318050840217/824583e0-4e65-11ec-bba0-7bf316bc7497_large.jpg"};

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var list_id_product = DataUtil.GetListIdProductByType(dbContext, (int)TypeProductEnum.DO_THE_THAO);
                    foreach (var id_product in list_id_product)
                    {
                        // mỗi product sẽ có 3 image_product
                        for (int i = 0; i < 3; i++)
                        {
                            var imageProduct = new ImageProduct
                            {
                                path = arr_path_img[random.Next(0, arr_path_img.Length)],
                                id_product = (long)id_product
                            };
                            dbContext.ImageProducts.Add(imageProduct);
                        }
                    }
                    dbContext.SaveChanges();
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
