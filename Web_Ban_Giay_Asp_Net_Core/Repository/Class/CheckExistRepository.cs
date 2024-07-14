using Web_Ban_Giay_Asp_Net_Core.DTOs;
using Web_Ban_Giay_Asp_Net_Core.Models.Request;

namespace Web_Ban_Giay_Asp_Net_Core.Repository.Class
{
    public class CheckExistRepository : ICheckExistRepository
    {
        private readonly MyDbContext _dbContext;

        public CheckExistRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
         * Kiểm tra sự tồn tại của tài khoản người dùng
         */
        public Task<InfoUserDTO> CheckExistOfAccountUser(ValidateUserRequest validateUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
