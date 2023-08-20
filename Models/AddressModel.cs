using System.ComponentModel.DataAnnotations;

namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class AddressModel
    {
        [Required(ErrorMessage = "Address is required.")]
        public string address { get; set; }

        [Required(ErrorMessage = "Ward name is required.")]
        public string ward_name { get; set; }

        [Required(ErrorMessage = "District name is required.")]
        public string district_name { get; set; }

        [Required(ErrorMessage = "Province name is required.")]
        public string province_name { get; set; }

        [Required(ErrorMessage = "Ward Id is required.")]
        public string ward_id { get; set; }

        [Required(ErrorMessage = "District Id is required.")]
        public string district_id { get; set; }

        [Required(ErrorMessage = "Province Id is required.")]
        public string province_id { get; set; }
    }
}
