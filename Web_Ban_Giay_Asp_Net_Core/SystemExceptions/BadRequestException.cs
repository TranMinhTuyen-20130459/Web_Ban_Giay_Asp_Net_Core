namespace Web_Ban_Giay_Asp_Net_Core.SystemExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
