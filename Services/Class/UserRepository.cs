namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel GetUser(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
