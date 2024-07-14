using Web_Ban_Giay_Asp_Net_Core.DTOs;
using Web_Ban_Giay_Asp_Net_Core.Models.Request;

namespace Web_Ban_Giay_Asp_Net_Core.Repository.Interface
{
    public interface ICheckExistRepository
    {
        /*
         * Kiểm tra sự tồn tại của tài khoản người dùng
         */
        Task<InfoUserDTO> CheckExistOfAccountUser(ValidateUserRequest validateUserRequest);
    }
}
