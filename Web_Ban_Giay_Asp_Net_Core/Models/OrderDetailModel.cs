
namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class OrderDetailModel
    {
        [Range(1, long.MaxValue, ErrorMessage = "Invalid product ID.")]
        public long id_product { get; set; }

        [Required(ErrorMessage = "Size name is required.")]
        public string name_size { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be >=1.")]
        public int quantity { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = "Price must be >= 0.")]
        public decimal price { get; set; }
    }
}
