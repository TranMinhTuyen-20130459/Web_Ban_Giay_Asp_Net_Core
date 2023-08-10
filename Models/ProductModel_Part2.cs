namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ProductModel_Part2
    {
        public long id_product { get; set; }

        public string name_product { get; set; }

        public int star_review { get; set; }

        public decimal listed_price { get; set; }

        public decimal promotional_price { get; set; }

        public List<ImageProductModel> list_image { get; set; }

        public int id_status_product { get; set; }
    }
}
