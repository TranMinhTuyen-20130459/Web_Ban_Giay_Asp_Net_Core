using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_admin { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public string? fullname { get; set; }

        public string? phone { get; set; }

        public string? path_img_avatar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("DateTime.Now")]
        public DateTime time_created { get; set; }

        public DateTime? time_updated { get; set; }

        public ICollection<RoleDetail> role_details { get; set; }
    }
}
