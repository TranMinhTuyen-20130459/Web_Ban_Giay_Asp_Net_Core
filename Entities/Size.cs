namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Sizes")]
    public class Size
    {
        [Key]
        public string name_size { get; set; }

        public ICollection<SizeProduct> size_products { get; set; }

    }
}
