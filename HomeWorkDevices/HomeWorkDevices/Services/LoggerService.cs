using System;
using HomeWorkDevices.Enums;
using Microsoft.Extensions.Options;
using HomeWorkDevices.Config;
using static System.Reflection.Metadata.BlobBuilder;
using System.Xml.Linq;
using HomeWorkDevices.Services.Abstractions;
using static HomeWorkDevices.Config.LoggerOption;

namespace HomeWorkDevices.Services
{
        public class LoggerService : ILoggerService
        {
            private readonly LoggerOption _loggerOption;
            private readonly List<string> _logs;

        public LoggerService(IOptions<LoggerOption> loggerOptions)
            {
                _loggerOption = loggerOptions.Value;
                _logs = new List<string>();
            }
        public void Log(LogType logType, string message)
        {
            var logger = $"{DateTime.UtcNow}: {logType}: {message}";

            try
            {
                var logDirectory = Path.GetDirectoryName(_loggerOption.Path);
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                using (var writer = File.AppendText(_loggerOption.Path))
                {
                    writer.WriteLine(logger);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log: {ex}");
            }

            _logs.Add(logger);
            Console.WriteLine("Log: " + logger);
        }
    }
}

