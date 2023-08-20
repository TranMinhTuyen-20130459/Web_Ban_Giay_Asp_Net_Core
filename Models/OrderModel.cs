using System.ComponentModel.DataAnnotations;

namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class OrderModel
    {

        [Required(ErrorMessage = "Customer name is required.")]
        public string name_customer { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? email_customer { get; set; }

        public AddressModel to_address { get; set; }

        [MaxLength(200, ErrorMessage = "Note cannot exceed 200 characters.")]
        public string? note { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Ship price must be >= 0")]
        public decimal ship_price { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Order value must be >= 0")]
        public decimal order_value { get; set; }

        public List<OrderDetailModel> list_order_detail { get; set; }
    }
}
