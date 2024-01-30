using System;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Services.Abstractions
{
	public interface ILoggerService
	{
		void Log(LogType logType, string message);
	}
}

