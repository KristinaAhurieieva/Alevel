using System;
using HomeWorkLoggerJSON.Services.Abstractions;
using HomeWorkLoggerJSON.Enums;
namespace HomeWorkLoggerJSON.Services
{
	public class LoggerService : ILoggerService
	{
        public void Log(LogType logType, string message)
        {
            var log = $"{DateTime.Now}: {logType}: {message}";
            Console.WriteLine(log);
        }
    }
}

