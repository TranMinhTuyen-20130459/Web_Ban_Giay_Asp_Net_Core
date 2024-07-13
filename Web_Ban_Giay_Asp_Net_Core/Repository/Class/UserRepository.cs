namespace Web_Ban_Giay_Asp_Net_Core.Repository.Class
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

            var queryResult = _dbContext.Users
                                .Where(u => u.email == loginModel.email && u.password == loginModel.password)
                                .Select(u => new { u.id_user, u.fullname, u.email, u.phone, })
                                .ToList();

            if (queryResult.Any())
            {
                var model = queryResult.Select(user => new UserModel
                {
                    id_user = user.id_user,
                    name = user.fullname,
                    email = user.email,
                    phone = user.phone
                }).SingleOrDefault();

                return model;
            }

            return null;
        }

        public User? GetUserById(int id_user)
        {
            return _dbContext.Users.SingleOrDefault(u => u.id_user == id_user);
        }
    }
}
