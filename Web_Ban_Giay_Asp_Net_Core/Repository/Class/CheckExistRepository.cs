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
        public async Task<InfoUserDTO?> CheckExistOfAccountUser(ValidateUserRequest validateUserRequest)
        {
            try
            {
                var user = await _dbContext.Users
                                     .Where(u => (validateUserRequest.email == u.email) && (validateUserRequest.password == u.password))
                                     .SingleOrDefaultAsync();

                if (user == null) return null;

                return InfoUserDTO.MapUserToInfoUserDTO(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
