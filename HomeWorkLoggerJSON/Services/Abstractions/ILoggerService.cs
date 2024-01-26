using System;
using HomeWorkLoggerJSON.Enums;
namespace HomeWorkLoggerJSON.Services.Abstractions
{
	public  interface ILoggerService
	{
        void Log(LogType logType, string message);
        

    }
}

