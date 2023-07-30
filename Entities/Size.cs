using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Sizes")]
    public class Size
    {
        [Key]
        public string name_size { get; set; }
    }
}
