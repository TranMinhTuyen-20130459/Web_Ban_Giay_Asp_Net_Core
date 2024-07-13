using Web_Ban_Giay_Asp_Net_Core.Constants.Enum;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class LoggerService<T> : ILogService<T>
    {
        private readonly ILogger<T> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggerService(ILogger<T> log, IHttpContextAccessor httpContextAccessor)
        {
            _logger = log;
            _httpContextAccessor = httpContextAccessor;
        }


        public void LogError(ETypeAction typeAction, string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(ETypeAction typeAction, string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void LogInformation(ETypeAction typeAction, string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(ETypeAction typeAction, string message)
        {
            throw new NotImplementedException();
        }
    }
}
