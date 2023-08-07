using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum StatusProduct
    {
        BINH_THUONG = 1,
        MOI = 2,
        HOT = 3,
        KHUYEN_MAI = 4,
        TAM_HET_HANG = 5,
        HET_HANG = 6,
        KHONG_DUOC_BAN = 7
    }
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_product { get; set; }

        [Required]
        public string name_product { get; set; }

        [Range(1, 5, ErrorMessage = "Star review must be between 1 and 5.")]
        public int star_review { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "id_status_product must be greater than or equal to 0.")]
        public int id_status_product { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Listed price must be greater than or equal to 0.")]
        public decimal listed_price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Promotional price must be greater than or equal to 0.")]
        public decimal promotional_price { get; set; }

        public ICollection<HistoryPriceProduct> list_history_price { get; set; }

        public ICollection<ImageProduct> list_image { get; set; }

        public ICollection<SizeProduct> list_size { get; set; }

        public ICollection<OrderDetail> list_order_detail { get; set; }

        [ForeignKey("id_brand")]
        public Brand brand { get; set; }

        [ForeignKey("id_type_product")]
        public TypeProduct type_product { get; set; }
    }
}
