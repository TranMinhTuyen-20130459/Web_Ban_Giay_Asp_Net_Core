namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ProductModel_Ver3
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự")]
        public string name_product { get; set; }

        [Range(4, 5, ErrorMessage = "Điểm đánh giá phải nằm trong khoảng từ 4 đến 5")]
        public int start_review { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá niêm yết không được nhỏ hơn 0")]
        public decimal listed_price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được nhỏ hơn 0")]
        public decimal promotional_price { get; set; }

        [Required(ErrorMessage = "Danh sách ảnh sản phẩm không được để trống")]
        public List<ImageProductModel_Ver2> list_image { get; set; }

        [Required(ErrorMessage = "Danh sách kích thước không được để trống")]
        public List<SizeProductModel> list_size { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "ID loại phải >=1")]
        public int id_type { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "ID thương hiệu phải >=1")]
        public int id_brand { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "ID giới tính phải >=1")]
        public byte id_sex { get; set; }
    }
}
