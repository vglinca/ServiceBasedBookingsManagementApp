using System;

namespace OnlineBookingAggregatorApp.Core.Exceptions
{
    public class DomainArgumentException : ArgumentException
    {
        public DomainArgumentException()
        {
        }

        public DomainArgumentException(string message) : base(message)
        {
        }

        public DomainArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DomainArgumentException(string message, string paramName) : base(message, paramName)
        {
        }

        public DomainArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}