namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MyDbContext _dbContext;

        public AdminRepository(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public AdminModel? GetAdmin(LoginModel loginModel)
        {
            var admin = _dbContext.Admins
                                  .Where(ad => (ad.email == loginModel.email) &&
                                               (ad.password == loginModel.password))
                                  .FirstOrDefault();

            if (admin != null)
            {
                var adminModel = new AdminModel
                {
                    id_admin = admin.id_admin,
                    name = admin.fullname,
                    email = admin.email,
                    phone = admin.phone
                };
                return adminModel;
            }

            return null;
        }
    }
}
