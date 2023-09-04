namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class SizeProductModel
    {
        [Required(ErrorMessage = "Name Size is required")]
        public string name_size { get; set; }

        [Required(ErrorMessage = "Quantity Available is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity Available must be >=0")]
        public int quantity_available { get; set; }
    }
}
