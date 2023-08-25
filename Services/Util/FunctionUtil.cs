using System.Text.RegularExpressions;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Util
{
    public class FunctionUtil
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Sử dụng Regular Expression để kiểm tra số điện thoại có đúng định dạng không
            // Trong ví dụ này, mẫu cho số điện thoại có 10 hoặc 11 chữ số
            var regex = new Regex(@"^[0-9]{10,11}$");
            return regex.IsMatch(phoneNumber);
        }

        public static string GenerateJwtToken(UserModel userModel)
        {
            return "";
        }

    }
}
