namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ProductModel_Ver3
    {
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters")]
        public string name_product { get; set; }

        [Range(4, 5, ErrorMessage = "Review Score must be between 4 and 5")]
        public int star_review { get; set; }

        [Required(ErrorMessage = "Listed price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Listed price must be >=0")]
        public decimal listed_price { get; set; }

        [Required(ErrorMessage = "Promotional price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Promotional price must be >=0")]
        public decimal promotional_price { get; set; }

        [Required(ErrorMessage = "List Image Product cannot be empty")]
        [MinLength(1, ErrorMessage = "List Image Product must contain at least one element")]
        public List<ImageProductModel_Ver2> list_image { get; set; }

        [Required(ErrorMessage = "List Size Product cannot be empty")]
        [MinLength(1, ErrorMessage = "List Size Product must contain at least one element")]
        public List<SizeProductModel> list_size { get; set; }

        [Required(ErrorMessage = "Type ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Type ID must be >= 1")]
        public int id_type { get; set; }

        [Required(ErrorMessage = "Brand ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Brand ID must be >= 1")]
        public int id_brand { get; set; }

        [Required(ErrorMessage = "Sex ID is required")]
        [Range(1, 2, ErrorMessage = "Sex ID must be >0 And <3")]
        public byte id_sex { get; set; }

        [Required(ErrorMessage = "Status Product ID is required")]
        [Range(1, 7, ErrorMessage = "Status Product ID must be >0 AND <8")]
        public int id_status_product { get; set; }
    }

}
