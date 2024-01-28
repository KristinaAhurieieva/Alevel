using System;
namespace HomeWorkLoggerJSON.Models
{
    public interface IActions
    {
        void WriteInfo();
        void ThrowBusinessException();
        void ThrowException();
    }
}

