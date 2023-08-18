namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class OrderDetailModel_Ver2
    {
        public long id_product { get; set; }
        public string name_product { get; set; }
        public ImageProductModel image_product { get; set; }
        public string name_size { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
