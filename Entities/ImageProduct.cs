﻿namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Image_Products")]
    public class ImageProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_image { get; set; }

        [Required]
        public string path { get; set; }

        public long id_product { get; set; }
        public Product product { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("DateTime.Now")]
        public DateTime time_created { get; set; }
    }
}
