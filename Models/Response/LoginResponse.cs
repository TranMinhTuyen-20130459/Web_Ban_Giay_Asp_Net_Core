namespace Web_Ban_Giay_Asp_Net_Core.Models.Response
{

    public static class TokenTypes
    {
        public static readonly string BEARER = "bearer";
    }

    public class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }
}
