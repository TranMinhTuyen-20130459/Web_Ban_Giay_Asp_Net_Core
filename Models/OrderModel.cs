namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class OrderModel
    {

        public string name_customer { get; set; }

        public string phone { get; set; }

        public string? email_customer { get; set; }

        public AddressModel to_address { get; set; }

        public string? note { get; set; }

        public decimal ship_price { get; set; }

        public decimal order_value { get; set; }

        public List<OrderDetailModel> list_order_detail { get; set; }
    }
}
