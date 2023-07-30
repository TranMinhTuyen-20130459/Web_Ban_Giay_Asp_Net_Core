﻿namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum StatusOrder
    {
        CHO_XAC_NHAN = 1,
        DA_XAC_NHAN = 2,
        CHO_LAY_HANG = 3,
        DANG_GIAO_HANG = 4,
        DA_GIAO_HANG = 5,
        TRA_HANG = 6,
        HUY_DON_HANG = 7
    }
    public class Order
    {
        public long id_order { get; set; }

        public string from_name { get; set; }
        public string from_phone { get; set; }
        public string from_address { get; set; }
        public string from_ward_name { get; set; }
        public string from_district_name { get; set; }
        public string from_province_name { get; set; }
        public string from_ward_id { get; set; }
        public string from_district_id { get; set; }
        public string from_province_id { get; set; }

        public string return_name { get; set; }
        public string return_phone { get; set; }
        public string return_address { get; set; }
        public string return_ward_name { get; set; }
        public string return_district_name { get; set; }
        public string return_province_name { get; set; }
        public string return_ward_id { get; set; }
        public string return_district_id { get; set; }
        public string return_province_id { get; set; }

        public string email_customer { get; set; }
        public string to_name { get; set; }
        public string to_phone { get; set; }
        public string to_address { get; set; }
        public string to_ward_name { get; set; }
        public string to_district_name { get; set; }
        public string to_province_name { get; set; }
        public string to_ward_id { get; set; }
        public string to_district_id { get; set; }
        public string to_province_id { get; set; }
        public string note { get; set; }

        public decimal ship_price { get; set; }
        public decimal order_value { get; set; }
        public decimal total_price { get; set; }

        public DateTime time_order { get; set; }
        public DateTime time_updated { get; set; }

        public int id_status_order { get; set; }
        public ICollection<OrderDetail> list_order_details { get; set; }

    }
}
