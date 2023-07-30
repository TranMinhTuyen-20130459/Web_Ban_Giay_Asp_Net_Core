using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("TestTables")]
    public class TestTable
    {
        [Key]
        public int id_test { get; set; }

        public string name_test { get; set; }
        
    }
}
