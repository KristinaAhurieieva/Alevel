using System.Net;
using Microsoft.Extensions.Logging;
using HomeWorkLoggerJSON.Services;
using HomeWorkLoggerJSON.Services.Abstractions;
using HomeWorkLoggerJSON;

class Program
{
    static void Main(string[] args)
    {
        ILoggerService loggerService = new LoggerService(); 
        ActionsService actionsService = new ActionsService(loggerService);

        App app = new App(actionsService, loggerService);


        FileService fileService = new FileService("Logs"); 

        try
        {
            app.Run();
            int result = DivideNumbers(10, 0);
        }
        catch (Exception ex)
        {
            fileService.WriteFile(ex);
        }
        static int DivideNumbers(int number, int numeral)
        {
            if (numeral == 0)
            {
                throw new ArgumentException("can't be zero");
            }

            return number / numeral;
        }
    }
}