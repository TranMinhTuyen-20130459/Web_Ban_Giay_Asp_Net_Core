using System.Collections;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Util
{
    public partial class DataUtil
    {

        public static ArrayList GetListIdProduct(MyDbContext dbContext)
        {
            var result = new ArrayList();
            try
            {
                // Sử dụng LINQ để chỉ chọn thuộc tính id_product từ bảng Products.
                List<long> list_id_product = dbContext.Set<Product>().Select(p => p.id_product).ToList();
                result = new ArrayList(list_id_product);
            }
            catch (Exception ex)
            {
                result = new ArrayList();
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public static ArrayList GetListIdProductByType(MyDbContext dbContext, int id_type)
        {
            var result = new ArrayList();
            try
            {
                List<long> list_id_product = dbContext.Set<Product>().Where(p => p.type_product.id_type == id_type).Select(p => p.id_product).ToList();
                result = new ArrayList(list_id_product);
            }
            catch (Exception ex)
            {
                result = new ArrayList();
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public static ArrayList GetListNameSize(MyDbContext dbContext)
        {
            var result = new ArrayList();
            try
            {
                List<string> list_name_size = dbContext.Set<Size>().Select(size => size.name_size).ToList();
                result = new ArrayList(list_name_size);
            }
            catch (Exception ex)
            {
                result = new ArrayList();
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        /*
         * Tạo ra tối đa 5 sản phẩm trong một đơn hàng dựa theo id_order,list_id_product,list_name_size
         */
        public static List<OrderDetail> CreateOrderDetailsRandom(long id_order, ArrayList list_id_product, ArrayList list_name_size)
        {
            var orderDetails = new List<OrderDetail>();
            var random = new Random();

            // Đảm bảo số lượng sản phẩm và kích thước có ít nhất một phần tử.
            if (list_id_product.Count > 0 && list_name_size.Count > 0)
            {
                var number = random.Next(1, 6);

                for (int i = 0; i < number; i++)
                {
                    // Chọn ngẫu nhiên một id_product và name_size từ danh sách tương ứng.
                    long randomProductId = (long)list_id_product[random.Next(list_id_product.Count)];
                    string randomNameSize = (string)list_name_size[random.Next(list_name_size.Count)];

                    // Tạo một OrderDetail mới và thêm vào danh sách.
                    var orderDetail = new OrderDetail
                    {
                        id_order = id_order,
                        id_product = randomProductId,
                        name_size = randomNameSize,
                        quantity = random.Next(1, 10),
                        price = random.Next(0, (int)(5 * Math.Pow(10, 5)))
                    };

                    orderDetails.Add(orderDetail);
                }
            }
            return orderDetails;
        }
    }
}
