using System.Diagnostics;
using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Data.Util;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataImageProductShoes : IAddData
    {
        public static string[] arr_path_img = {
            "https://kingshoes.vn/data/upload/media/dv3854-600-giay-nike-pegasus-40-road-running-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dv7480-100-giay-chay-bo-nike-pegasus-40-wide-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dr2698-004-giay-nike-run-swift-3-womens-road-running-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/fd0374-410-giay-nike-air-max-90-se-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dq5972-100-giay-nike-air-force-1-lv8-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/fj5450-100-giay-nike-air-max-270-se-chinh-hang-gia-tot-den-king-shoes-13.jpeg"
            , "https://kingshoes.vn/data/upload/media/dx9176-102-giay-nike-gamma-force-womens-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dm2845-100-giay-nike-air-force-1-07-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/SNEAKER-315122-111-AIR-FORCE-1-07-NIKE-KINGSHOES.VN-TPHCM-TANBINH-17-logo-1551924204-.jpg"
            , "https://kingshoes.vn/data/upload/media/dr2698-600-giay-nike-run-swift-3-womens-road-running-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/gx7256-giay-adidas-galaxy-6-w-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/gz4900-giay-adidas-znchill-lightmotion-chinh-hang-gia-tot-den-king-shoes-21.jpg"
            , "https://kingshoes.vn/data/upload/media/hp7567-giay-adidas-runfalcon-3-tr-running-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/gw8682-giay-adidas-ultraboost-og-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/eg0705-giay-adidas-ultraboost-20-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/hq6874-giay-forum-low-cl-trang-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/hp9732-giay-adidas-ultra-4d-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/h02334-giay-adidas-nmd-r1-refined-chinh-hang-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/hq0949-giay-adidas-ultra-4d-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/gz2618-giay-adidas-znchill-lightmotion-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/553558-030-giay-nike-air-jordan-1-low-light-smoke-grey-chinh-hang-gia-tot-den-king-shoes-8.jpeg"
            , "https://kingshoes.vn/data/upload/media/do9369-101-giay-nike-air-jordan-1-starfish-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dz5485-303-giay-nike-air-jordan-1-retro-high-og-gorge-green-chinh-hang-gia-tot-den-king-shoes-13.jpeg"
            , "https://kingshoes.vn/data/upload/media/ct0979-602-giay-nike-air-jordan-1-high-zoom-cmft-canyon-rust-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/554724-091-giay-nike-air-jordan-1-mid-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/554724-122-giay-nike-air-jordan-1-black-white-red-chinh-hang-gia-tot-den-king-shoes-1.jpg"
            , "https://kingshoes.vn/data/upload/media/dr5415-103-giay-nike-sb-x-air-jordan-4-pine-green-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dz5485-612-giay-nike-air-jordan-1-chicago-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
            , "https://kingshoes.vn/data/upload/media/dn1635-100-giay-nike-air-jordan-1-low-inside-out-chinh-hang-gia-tot-den-king-shoes-15.jpeg"
            , "https://kingshoes.vn/data/upload/media/bq4422-001-giay-nike-air-jordan-1-retro-high-85-black-white-chinh-hang-gia-tot-den-king-shoes-12.jpeg"
    };

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var list_id_product = DataUtil.GetListIdProductByType(dbContext, (int)TypeProductEnum.GIAY);
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
