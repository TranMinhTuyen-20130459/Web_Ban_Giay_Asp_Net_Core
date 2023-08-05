using System.Collections;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Util
{
    public partial class DataUtil
    {
        public static ArrayList GetListIdOrder(MyDbContext dbContext)
        {
            var result = new ArrayList();
            try
            {
                List<long> list_id_order = dbContext.Set<Order>().Select(order => order.id_order).ToList();
                result = new ArrayList(list_id_order);
            }
            catch (Exception ex)
            {
                result = new ArrayList();
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
