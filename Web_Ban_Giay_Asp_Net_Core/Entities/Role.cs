namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_role { get; set; }

        [Required]
        public string name_role { get; set; }

        public ICollection<RoleDetail> role_details { get; set; }
    }
}
