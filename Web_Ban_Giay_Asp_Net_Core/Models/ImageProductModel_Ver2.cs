namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ImageProductModel_Ver2
    {
        [Required(ErrorMessage = "Path_image is required")]
        [MinLength(15, ErrorMessage = "Path_image must be at least 15 characters long")]
        public string path_image { get; set; }
    }
}