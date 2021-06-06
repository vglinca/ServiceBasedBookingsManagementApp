using System;

namespace OnlineBookingAggregatorApp.Core.Exceptions
{
    public class DomainInvalidOperationException : InvalidOperationException
    {
        public DomainInvalidOperationException()
        {
        }

        public DomainInvalidOperationException(string message) : base(message)
        {
        }

        public DomainInvalidOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}