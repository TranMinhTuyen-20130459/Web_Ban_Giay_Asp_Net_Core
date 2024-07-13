using Web_Ban_Giay_Asp_Net_Core.Constants.Enum;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface ILogService<T>
    {
        void LogInformation(ETypeAction typeAction, string message);
        void LogWarning(ETypeAction typeAction, string message);
        void LogError(ETypeAction typeAction, string message);
        void LogError(ETypeAction typeAction, string message, Exception exception);
    }
}
