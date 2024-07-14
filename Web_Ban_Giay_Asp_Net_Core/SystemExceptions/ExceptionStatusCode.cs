namespace Web_Ban_Giay_Asp_Net_Core.SystemExceptions
{
    public static class ExceptionStatusCode
    {
        private static readonly Dictionary<Type, HttpStatusCode> exceptionStatusCode = new()
        {
            {typeof(AuthenticationException), HttpStatusCode.Unauthorized},
            {typeof(NotFoundException), HttpStatusCode.NotFound},
            {typeof(BadRequestException), HttpStatusCode.BadRequest}
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exceptionStatusCode.TryGetValue(exception.GetType(), out HttpStatusCode statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}
