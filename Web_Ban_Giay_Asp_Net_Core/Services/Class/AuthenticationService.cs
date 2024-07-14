using Web_Ban_Giay_Asp_Net_Core.Models.Request;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

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
        public Task<ValidateUserResponse> ValidateUser(ValidateUserRequest validateUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
