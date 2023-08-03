﻿using System.Collections;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Util
{
    public class DataUtil
    {
        public static void PrintArrayList(ArrayList arrayList)
        {
            foreach (var item in arrayList)
            {
                Console.Write(item + ",");
            }
        }

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
    }
}
