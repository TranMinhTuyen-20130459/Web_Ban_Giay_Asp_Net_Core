namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Size_Products")]
    public class SizeProduct
    {

        public long id_product { get; set; }
        public Product product { get; set; }

        public string name_size { get; set; }
        public Size size { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value of quantity_available must be greater than or equal to 0.")]
        public int quantity_available { get; set; }
    }
}
