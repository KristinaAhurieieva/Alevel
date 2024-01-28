using System;
using HomeWorkLoggerJSON.Enums;
using HomeWorkLoggerJSON.Models;
using HomeWorkLoggerJSON.Services.Abstractions;
namespace HomeWorkLoggerJSON.Services
{
	public class ActionsService : IActions
	{
        private readonly ILoggerService log;

        public ActionsService(ILoggerService log)
        {
            this.log = log;
        }

        public void WriteInfo()
        {
            log.Log(LogType.Info, "Start method: WriteInfo");
        }
        public void ThrowBusinessException()
        {
            throw new BusinessException("Skipped logic in method");  
        }

        public void ThrowException()
        {
            throw new Exception ("I broke a logic");
        }
            
    }
}

