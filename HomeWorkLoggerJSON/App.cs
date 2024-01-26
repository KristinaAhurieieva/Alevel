using System;
using HomeWorkLoggerJSON.Services;
using HomeWorkLoggerJSON.Models;
using HomeWorkLoggerJSON.Services.Abstractions;
using HomeWorkLoggerJSON.Enums;

namespace HomeWorkLoggerJSON
{
	public class App
	{
        private readonly ActionsService actions;
        private readonly ILoggerService logger;

        public App(ActionsService actions, ILoggerService logger)
        {
            this.actions = actions;
            this.logger = logger;
        }
        public void Run ()
		{
            Random random = new Random();
            for (int idx = 1; idx <= 100; idx++)
            {
                try
                {
                    int randomIdx = random.Next(1, 4);
                    switch (randomIdx)
                    {
                        case 1:
                            actions.WriteInfo();
                            break;
                        case 2:
                            actions.ThrowBusinessException();
                            break;
                        case 3:
                            actions.ThrowException();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    logger.Log(LogType.Warning, $"Action got this custom Exception :{ex.Message}");
                }
                catch(Exception ex)
                {
                    logger.Log(LogType.Error, $"Action failed by reason: {ex}");
                }
			}
		}
	}
}

