namespace Web_Ban_Giay_Asp_Net_Core.DTOs
{
    public class InfoUserDTO
    {
        public long idUser { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public static InfoUserDTO MapUserToInfoUserDTO(User user)
        {
            return new InfoUserDTO
            {
                idUser = user.id_user,
                name = user.fullname,
                email = user.email,
                phone = user.phone
            };
        }
    }
}
