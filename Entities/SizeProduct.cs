using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Size_Products")]
    public class SizeProduct
    {
        public Product product { get; set; }

        public Size size { get; set; }

        public int quantity_available { get; set; }
    }
}
