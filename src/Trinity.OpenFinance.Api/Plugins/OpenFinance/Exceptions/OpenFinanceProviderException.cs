using System;
using System.Runtime.Serialization;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Exceptions
{
    [Serializable]
    public class OpenFinanceProviderException : Exception
    {
        public OpenFinanceProviderException()
        {
        }

        public OpenFinanceProviderException(string message) : base(message)
        {
        }

        public OpenFinanceProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OpenFinanceProviderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}