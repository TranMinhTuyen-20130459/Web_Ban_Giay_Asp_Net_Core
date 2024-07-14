using Web_Ban_Giay_Asp_Net_Core.Models.Request;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class AuthenticationService : IAuthentication
    {
        private readonly ICheckExistRepository _checkExistRepository;
        private readonly JWTHelper _jwtHelper;

        public AuthenticationService(ICheckExistRepository checkExistRepository, JWTHelper jwtHelper)
        {
            _checkExistRepository = checkExistRepository;
            _jwtHelper = jwtHelper;
        }

        /*
         * Xác thực người dùng khi đăng nhập vào hệ thống
         * Nếu:
         * - Tài khoản không tồn tại => Trả về { mã lỗi 404 kèm theo thông báo "Tài khoản hoặc mật khẩu không đúng" }
         * - Tài khoản tồn tại 
         *      => Trả về các thông tin sau:
         *      { 
         *        mã trạng thái: 200,
         *        thông tin người dùng,
         *        chuỗi accessToken,
         *        chuỗi refreshToken
         *      }
         */
        public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest validateUserRequest)
        {
            var infoUser = await _checkExistRepository.CheckExistOfAccountUser(validateUserRequest);

            if (infoUser == null) throw new NotFoundException("Tài khoản hoặc mật khẩu không đúng");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, infoUser?.idUser.ToString() ?? ""),
                new Claim(ClaimTypes.Name, infoUser?.name ?? ""),
                new Claim(ClaimTypes.Email, infoUser?.email ?? ""),
                new Claim(ClaimTypes.MobilePhone, infoUser?.phone ?? "")
            };

            SigningCredentials signingCredentials = _jwtHelper.GetSigningCredentials();

            return new ValidateUserResponse
            {
                idUser = infoUser.idUser,
                name = infoUser.name,
                email = infoUser.email,
                phone = infoUser.phone,
                accessToken = _jwtHelper.CreateToken(signingCredentials, claims),
                refreshToken = "123"
            };
        }
    }
}
