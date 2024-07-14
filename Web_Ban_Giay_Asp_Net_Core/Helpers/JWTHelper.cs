using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web_Ban_Giay_Asp_Net_Core.Helpers
{
    public class JWTHelper
    {
        private readonly IConfiguration _configuration;

        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /**
         * Hàm này dùng để tạo ra một đối tượng SigningCredentials từ secret key
         * => nó chứa thông tin cần thiết để ký một token, bao gồm khóa bí mật (secret key) và thuật toán ký
         */
        public SigningCredentials GetSigningCredentials()
        {

            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));

            var secretKey = new SymmetricSecurityKey(key);

            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
             );

            return tokenOptions;
        }

        public string CreateToken(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
