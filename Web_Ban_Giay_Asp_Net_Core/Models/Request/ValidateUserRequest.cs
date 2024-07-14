using System.ComponentModel.DataAnnotations;

namespace Web_Ban_Giay_Asp_Net_Core.Models.Request
{
    public class ValidateUserRequest
    {
        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password là bắt buộc")]
        [MinLength(6, ErrorMessage = "Password phải có ít nhất 6 ký tự")]
        public string password { get; set; }
    }
}
