namespace Web_Ban_Giay_Asp_Net_Core.Repository.Interface
{
    public interface IAdminRepository
    {
        // Lấy ra thông tin Admin dựa vào thông tin đăng nhập,sau đó chuyển thành model
        AdminModel? GetAdmin(LoginModel loginModel);
    }
}
