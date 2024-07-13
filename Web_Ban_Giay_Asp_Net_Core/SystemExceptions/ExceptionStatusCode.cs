namespace Web_Ban_Giay_Asp_Net_Core.SystemExceptions
{
    public static class ExceptionStatusCode
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCode = new()
        {
            {typeof(AuthenticationException), HttpStatusCode.Unauthorized},
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exceptionStatusCode.TryGetValue(exception.GetType(), out HttpStatusCode statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}
