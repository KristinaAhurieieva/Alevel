using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ThirdModule.Config;
using ThirdModule.Service;

public class App
{
    static async Task Main()
    {
        var config = Config();

        AsyncLogger logger = new AsyncLogger("log.txt", "Backup", config.copyFrequency);
        logger.Backup += async (sender, args) => await logger.PerformAsyncBackup();

        Task logTask1 = Task.Run(async () => await LogMessagesAsync(logger, 50));
        await Task.Delay(100);
        Task logTask2 = Task.Run(async () => await LogMessagesAsync(logger, 50));

        await Task.WhenAll(logTask1, logTask2);
        await logger.PerformAsyncBackup();
    }

    static async Task LogMessagesAsync(AsyncLogger logger, int count, int currentOperation = 0)
    {
        if (currentOperation == count)
        {
            return;
        }

        await logger.LogAsync($"Message {currentOperation + 1}");
        await LogMessagesAsync(logger, count, currentOperation + 1);
    }

    static AppConfig Config()
    {
        string json = File.ReadAllText("/Users/kristinaagureeva/Projects/ThirdModule/ThirdModule/config.json");
        return JsonSerializer.Deserialize<AppConfig>(json);
    }
}