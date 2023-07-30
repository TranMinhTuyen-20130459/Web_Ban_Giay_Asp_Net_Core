namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class ImageProduct
    {
        public long id_image { get; set; }

        public string path { get; set; }

        public Product product { get; set; }
    }
}
