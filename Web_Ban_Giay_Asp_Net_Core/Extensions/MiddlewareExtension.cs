using Web_Ban_Giay_Asp_Net_Core.Middlewares;

namespace Web_Ban_Giay_Asp_Net_Core.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
