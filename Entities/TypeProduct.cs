using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum TypeProductEnum
    {
        GIAY = 1,
        DEP = 2,
        PHU_KIEN = 3
    }

    [Table("Type_Products")]
    public class TypeProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_type { get; set; }

        [Required]
        public string name_type { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
