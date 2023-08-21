using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Role_Details")]
    public class RoleDetail
    {
        public long id_admin { get; set; }
        public Admin admin { get; set; }

        public int id_role { get; set; }
        public Role role { get; set; }
    }
}
