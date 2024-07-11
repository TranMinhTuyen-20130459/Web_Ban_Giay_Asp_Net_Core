using System.Diagnostics;

namespace DataTest.Data.Class
{
    public class DataOrder : IAddData
    {
        public string[] arr_name_senders = { "MESSI", "RONALDO", "NEYMAR", "MBAPPE", "BENZEMA" };

        public string[] arr_name_receivers = { "TUYEN 1", "TUYEN 2", "TUYEN 3", "TUYEN 4", "TUYEN 5" };

        public string[] arr_email_customers = {"trantuyen.dev.1@gmail.com", "trantuyen.dev.2@gmail.com", "trantuyen.dev.3@gmail.com",
            "trantuyen.dev.4@gmail.com", "trantuyen.developer.981@gmail.com"};

        public string[] arr_phone_receiver = { "0927042108", "1927142108", "2927242108", "3927342108", "4927442108" };

        public string[] arr_address = { "256 LÊ VĂN QUỚI", "CƯ XÁ A KHU PHỐ 6", "TRƯỜNG ĐẠI HỌC NÔNG LÂM" };

        public string[] arr_name_wards = {"PHƯỜNG 1", "PHƯỜNG 2", "PHƯỜNG 3", "PHƯỜNG 4", "PHƯỜNG 5",
            "PHƯỜNG 6", "PHƯỜNG 7", "PHƯỜNG 8", "PHƯỜNG 9", "PHƯỜNG 10",
            "PHƯỜNG 11", "PHƯỜNG 12", "PHƯỜNG 13", "PHƯỜNG 14", "PHƯỜNG 15"};

        public string[] arr_id_wards = { "W1", "W2", "W3", "W4", "W5", "W6", "W7", "W8", "W9", "W10", "W11", "W12", "W13", "W14", "W15" };

        public string[] arr_name_districts = {"QUẬN 1", "QUẬN 2", "QUẬN 3", "QUẬN 4", "QUẬN 5",
            "QUẬN 6", "QUẬN 7", "QUẬN 8", "QUẬN 9", "QUẬN 10",
            "QUẬN 11", "QUẬN 12", "QUẬN 13", "QUẬN 14", "QUẬN 15",};

        public string[] arr_id_districts = {"D1", "D2", "D3", "D4", "D5",
            "D6", "D7", "D8", "D9", "D10",
            "D11", "D12", "D13", "D14", "D15"};

        public string[] arr_name_provinces = {"THÀNH PHỐ 1", "THÀNH PHỐ 2", "THÀNH PHỐ 3", "THÀNH PHỐ 4", "THÀNH PHỐ 5",
            "THÀNH PHỐ 6", "THÀNH PHỐ 7", "THÀNH PHỐ 8", "THÀNH PHỐ 9", "THÀNH PHỐ 10",
            "THÀNH PHỐ 11", "THÀNH PHỐ 12", "THÀNH PHỐ 13", "THÀNH PHỐ 14", "THÀNH PHỐ 15"};

        public string[] arr_id_provinces = {"P1", "P2", "P3", "P4", "P5",
            "P6", "P7", "P8", "P9", "P10",
            "P11", "P12", "P13", "P14", "P15"};

        public string[] arr_phone_senders = { "0379342981", "1379442981", "2379542981", "3379642981", "4379742981" };

        public void AddDataToTable(MyDbContext dbContext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var list_id_product = DataUtil.GetListIdProduct(dbContext);
                    var list_name_size = DataUtil.GetListNameSize(dbContext);

                    // tạo mới 1000 đơn hàng
                    for (int i = 0; i < 100; i++)
                    {
                        int index_ward_from = random.Next(0, arr_name_wards.Length);
                        int index_district_from = random.Next(0, arr_name_districts.Length);
                        int index_province_from = random.Next(0, arr_name_provinces.Length);

                        int index_ward_to = random.Next(0, arr_name_wards.Length);
                        int index_district_to = random.Next(0, arr_name_districts.Length);
                        int index_province_to = random.Next(0, arr_name_provinces.Length);

                        // phí ship từ 0 cho đến 500 ngàn 
                        var ship_price = random.Next(0, (int)(5 * Math.Pow(10, 5)));

                        // đơn hàng có trị giá từ 0 cho đến 500 triệu đồng
                        var order_value = random.Next(0, (int)(500 * Math.Pow(10, 6)));

                        var order = new Order
                        {
                            from_name = arr_name_senders[random.Next(0, arr_name_senders.Length)],
                            from_phone = arr_phone_senders[random.Next(0, arr_phone_senders.Length)],

                            from_address = arr_address[random.Next(0, arr_address.Length)],
                            from_ward_name = arr_name_wards[index_ward_from],
                            from_ward_id = arr_id_wards[index_ward_from],
                            from_district_name = arr_name_districts[index_district_from],
                            from_district_id = arr_id_districts[index_district_from],
                            from_province_name = arr_name_provinces[index_province_from],
                            from_province_id = arr_id_provinces[index_province_from],

                            to_name = arr_name_receivers[random.Next(0, arr_name_receivers.Length)],
                            to_phone = arr_phone_receiver[random.Next(0, arr_phone_receiver.Length)],

                            to_address = arr_address[random.Next(0, arr_address.Length)],
                            to_ward_name = arr_name_wards[index_ward_to],
                            to_ward_id = arr_id_wards[index_ward_to],
                            to_district_name = arr_name_districts[index_district_to],
                            to_district_id = arr_id_districts[index_district_to],
                            to_province_name = arr_name_provinces[index_province_to],
                            to_province_id = arr_id_provinces[index_province_to],

                            email_customer = arr_email_customers[random.Next(0, arr_email_customers.Length)],

                            ship_price = ship_price,
                            order_value = order_value,
                            total_price = ship_price + order_value,

                            id_status_order = random.Next(1, 8),// id_status_order từ 1 đến 7
                            id_status_payment = random.Next(1, 3), // id_status_payment từ 1 đến 2
                            id_method_payment = random.Next(1, 4), // id_method_payment từ 1 đến 3
                        };
                        dbContext.Orders.Add(order);
                        dbContext.SaveChanges();

                        var id_order = order.id_order;

                        // Tạo ds chi tiết đơn hàng ngẫu nhiên 
                        var list_order_detail = DataUtil.CreateOrderDetailsRandom(id_order, list_id_product, list_name_size);

                        list_order_detail.ForEach(od =>
                        {
                            dbContext.OrderDetails.Add(od);
                        });
                        dbContext.SaveChanges();
                    }
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
