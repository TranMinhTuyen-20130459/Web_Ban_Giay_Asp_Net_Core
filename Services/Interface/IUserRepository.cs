using Web_Ban_Giay_Asp_Net_Core.Models;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IUserRepository
    {
        // lấy ra thông tin của User dựa vào thông tin đăng nhập, sau đó chuyển thành model  
        public UserModel GetUser(LoginModel loginModel);
    }
}
