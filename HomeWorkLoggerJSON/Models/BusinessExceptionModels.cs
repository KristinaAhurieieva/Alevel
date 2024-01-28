using System;
namespace HomeWorkLoggerJSON.Models
{
	public class BusinessException : Exception
	{
        public BusinessException(string message) : base(message)
        {

        }
    }
}

