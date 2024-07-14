using Web_Ban_Giay_Asp_Net_Core.SystemExceptions;

namespace Web_Ban_Giay_Asp_Net_Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)ExceptionStatusCode.GetExceptionStatusCode(ex);

                var errorResponse = new ErrorResponse
                {
                    statusCode = httpContext.Response.StatusCode,
                    errorMessage = ex.Message
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
