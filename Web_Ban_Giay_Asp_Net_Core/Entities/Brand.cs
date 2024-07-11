namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum BrandEnum
    {
        NIKE = 1,
        ADIDAS = 2,
        JORDAN = 3
    }

    [Table("Brands")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_brand { get; set; }

        [Required]
        public string name_brand { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
