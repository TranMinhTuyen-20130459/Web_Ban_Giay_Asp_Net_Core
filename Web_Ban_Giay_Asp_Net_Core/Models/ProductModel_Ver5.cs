namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ProductModel_Ver5
    {
        [Required(ErrorMessage = "Product Id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Product Id must be >=1")]
        public long id_product { get; set; }
    }
}
