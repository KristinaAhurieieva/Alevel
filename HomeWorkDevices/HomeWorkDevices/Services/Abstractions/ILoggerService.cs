
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Services.Abstractions
{
    public interface ILoggerService
    {
        event LogHandler LogEvent;
        void Log(LogType logType, string message);
    }
}

