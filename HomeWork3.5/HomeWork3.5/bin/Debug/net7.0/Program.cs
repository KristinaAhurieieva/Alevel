class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string result = await ReadDataFile("Hello", "World");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadLine();
    }
    static async Task<string> ReadDataFile(string fileone, string filenametwo)
    {
        Task<string> task1 = ReadFileAsync(fileone);
        Task<string> task2 = ReadFileAsync(filenametwo);

        await Task.WhenAll(task1, task2);

        return task1.Result + task2.Result;
    }

    static async Task<string> ReadFileAsync(string filename)
    {
        using StreamReader reader = new StreamReader(filename);
        return await reader.ReadToEndAsync();
    }
}














