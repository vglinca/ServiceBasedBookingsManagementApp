using System;

namespace OnlineBookingAggregatorApp.Core.Exceptions
{
    public class InfrastructureArgumentNullException : ArgumentNullException
    {
        public InfrastructureArgumentNullException()
        {
        }

        public InfrastructureArgumentNullException(string paramName) : base(paramName)
        {
        }

        public InfrastructureArgumentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InfrastructureArgumentNullException(string paramName, string message) : base(paramName, message)
        {
        }
    }
}