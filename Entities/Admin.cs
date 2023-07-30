namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class Admin
    {
        public string username { get; set; }

        public string password { get; set; }

        public string fullname { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string path_img_avatar { get; set; }

        public ICollection<RoleDetail> roles { get; set; }
    }
}
