namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ImageProductModel
    {
        [Required(ErrorMessage = "Id_image is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Id_image must be greater than 0")]
        public long? id_image { get; set; }

        [Required(ErrorMessage = "Path_image is required")]
        [MinLength(15, ErrorMessage = "Path_image must be at least 15 characters long")]
        public string? path_image { get; set; }
    }
}
