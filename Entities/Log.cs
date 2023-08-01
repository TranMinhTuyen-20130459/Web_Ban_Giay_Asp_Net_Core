using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum LevelLog
    {
        Infor = 1, Warning = 2, Error = 3, Alert = 4
    }

    [Table("Logs")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_log { get; set; }

        [Required]
        public int id_user { get; set; }

        [Required]
        public string? src { get; set; }

        [Required]
        public string? content { get; set; }

        [Required]
        public string? id_address { get; set; }

        [Required]
        public string? web_browser { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("DateTime.Now")]
        public DateTime create_at { get; set; }

        public string? status { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value of id_level_log must be greater than or equal to 0.")]
        public int id_level_log { get; set; }

    }
}
