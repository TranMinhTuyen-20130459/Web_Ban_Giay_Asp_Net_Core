namespace Web_Ban_Giay_Asp_Net_Core.Models.Response
{
    public class LoginUserResponse
    {
        public long idUser { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
