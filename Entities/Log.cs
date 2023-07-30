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
        public int id_log { get; set; }

        public int id_user { get; set; }

        public string? src { get; set; }

        public string? content { get; set; }

        public string? id_address { get; set; }

        public string? web_browser { get; set; }

        public DateTime create_at { get; set; }

        public string? status { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value of id_level_log must be greater than or equal to 0.")]
        public int id_level_log { get; set; }

    }
}
