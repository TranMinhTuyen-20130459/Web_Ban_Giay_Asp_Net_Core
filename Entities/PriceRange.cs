using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Price_Ranges")]
    public class PriceRange
    {
        [Key]
        public string name_price_range { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value of price_start must be greater than or equal to 0.")]
        public decimal price_start { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value of price_end must be greater than or equal to 0.")]
        public decimal price_end { get; set; }
    }
}
