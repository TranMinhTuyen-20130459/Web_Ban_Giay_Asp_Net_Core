namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class TypeProduct
    {
        public int id_type { get; set; }

        public string name_type { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
