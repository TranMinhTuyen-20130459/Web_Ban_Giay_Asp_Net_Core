using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        public string username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string password { get; set; }

        public string fullname { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string phone { get; set; }

        public string path_img_avatar { get; set; }

        public ICollection<RoleDetail> role_details { get; set; }
    }
}
