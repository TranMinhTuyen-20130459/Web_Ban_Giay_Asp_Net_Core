using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Web_Ban_Giay_Asp_Net_Core.Repository.Util
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

        // Phương thức GenerateJwtToken được sử dụng để tạo mã token JWT dựa trên thông tin người dùng và cài đặt ứng dụng
        public static string GenerateJwtToken(UserModel userModel, AppSettings _appSettings)
        {
            // Khởi tạo đối tượng để xử lý token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Chuyển đổi khóa bí mật từ chuỗi thành mảng bytes
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            // Mô tả cho thông tin trong token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Xác định thông tin trong token (ở đây chỉ có "id" của người dùng)
                Subject = new ClaimsIdentity(new[] { new Claim("id", userModel.id_user.ToString()) }),

                // Thời gian hết hạn của token (3 phút kể từ thời điểm tạo)
                Expires = DateTime.UtcNow.AddMinutes(3),

                // Xác thực và ký token bằng thuật toán HMAC SHA-256 sử dụng khóa bí mật
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Tạo mã token dựa trên mô tả đã thiết lập
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Trả về mã token dưới dạng chuỗi
            return tokenHandler.WriteToken(token);
        }


    }
}
