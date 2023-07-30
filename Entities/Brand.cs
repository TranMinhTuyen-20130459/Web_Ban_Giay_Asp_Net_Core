namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class Brand
    {
        public int id_brand { get; set; }

        public int name_brand { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
