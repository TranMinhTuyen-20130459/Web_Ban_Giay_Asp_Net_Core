﻿namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    /*
     * đây là Model định nghĩa chuỗi Json để cập nhật thông tin của sản phẩm 
     */
    public class ProductModel_Ver4
    {
        [Required(ErrorMessage = "Product Id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Product Id must be >=1")]
        public long id_product { get; set; }

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

        public List<SizeProductModel>? list_size { get; set; }

        public List<ImageProductModel>? list_image { get; set; }

    }
}
