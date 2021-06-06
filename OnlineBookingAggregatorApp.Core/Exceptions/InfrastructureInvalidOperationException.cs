using System;

namespace OnlineBookingAggregatorApp.Core.Exceptions
{
    public class InfrastructureInvalidOperationException : Exception
    {
        public InfrastructureInvalidOperationException()
        {
        }

        public InfrastructureInvalidOperationException(string message) : base(message)
        {
        }

        public InfrastructureInvalidOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}