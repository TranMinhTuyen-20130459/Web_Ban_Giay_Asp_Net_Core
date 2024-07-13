namespace Web_Ban_Giay_Asp_Net_Core.Repository.Interface
{
    public interface IUserRepository
    {
        // lấy ra thông tin của User dựa vào thông tin đăng nhập, sau đó chuyển thành model  
        public UserModel GetUser(LoginModel loginModel);

        // lấy ra User dựa vào id_user
        User? GetUserById(int id_user);
    }
}
