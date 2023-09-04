namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class ImageProductModel_Ver2
    {
        [Required(ErrorMessage = "Path Image is required")]
        public string path_image { get; set; }
    }
}