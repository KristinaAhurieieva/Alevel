
using HomeWorkDevices.Enums;
using Microsoft.Extensions.Options;
using HomeWorkDevices.Config;
using HomeWorkDevices.Services.Abstractions;


namespace HomeWorkDevices.Services
{
    public delegate void LogHandler(LogType logType, string message);

    public class LoggerService : ILoggerService
    {
        private readonly LoggerOption loggerOption;

        public event LogHandler LogEvent;

        public LoggerService(IOptions<LoggerOption> loggerOptions)
        {
            loggerOption = loggerOptions.Value;
        }

        public void Log(LogType logType, string message)
        {
            var log = $"{DateTime.UtcNow}: {logType}: {message}";

            try
            {
                var logDirectory = Path.GetDirectoryName(loggerOption.Path);
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                Console.WriteLine($"Log directory: {logDirectory}"); 

                using (var writer = File.AppendText(loggerOption.Path))
                {
                    writer.WriteLine(log);
                    Console.WriteLine($"Log written to file: {loggerOption.Path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log: {ex}");
            }

            LogEvent?.Invoke(logType, message);
            Console.WriteLine("Log: " + log);
        }
    }
}

