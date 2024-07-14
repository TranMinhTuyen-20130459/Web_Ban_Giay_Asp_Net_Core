using Web_Ban_Giay_Asp_Net_Core.Models.Request;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IAuthentication
    {
        /*
         * Xác thực người dùng khi đăng nhập vào hệ thống
         */
        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest validateUserRequest);
    }
}
