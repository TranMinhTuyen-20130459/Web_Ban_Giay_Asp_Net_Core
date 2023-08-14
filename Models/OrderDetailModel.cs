namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class OrderDetailModel
    {
        public long id_product { get; set; }

        public string name_size { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }
    }
}
