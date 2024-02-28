using System;
using Microsoft.Extensions.Logging.Abstractions;
using ThirdModule.Enums;

namespace ThirdModule.Service
{
    public class AsyncLogger
    {
        public event EventHandler? Backup;

        private readonly string logFilePath;
        private readonly string backupFolderPath;
        private readonly int copyFrequency;
        private int logCount;

        public AsyncLogger(string filePath, string backupFolder, int copyFrequency)
        {
            logFilePath = filePath;
            backupFolderPath = backupFolder;
            this.copyFrequency = copyFrequency;
            logCount = 1;
        }

        protected virtual void PerformBackup()
        {
            Backup?.Invoke(this, EventArgs.Empty);
        }

        public async Task LogAsync(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}{Environment.NewLine}";

            try
            {
                await WriteFileAsync(logEntry);

                logCount++;

                if (logCount % copyFrequency == 0)
                {
                    PerformBackup();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        private async Task WriteFileAsync(string logEntry)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                await writer.WriteAsync(logEntry);
            }
            await Task.Delay(100);
        }

        public async Task PerformAsyncBackup()
        {
            try
            {
             string backupFile = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
             string backupFilePath = Path.Combine(backupFolderPath, backupFile);

             string logData;

            using (StreamReader reader = new StreamReader(logFilePath))
                {
                    logData = await reader.ReadToEndAsync();
                }
            using (StreamWriter writer = new StreamWriter(backupFilePath, true))
                {
                    await writer.WriteAsync(logData);
                }

            Console.WriteLine($"Created: {backupFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}