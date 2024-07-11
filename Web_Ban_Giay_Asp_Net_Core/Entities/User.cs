namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_user { get; set; }

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

    }

}
