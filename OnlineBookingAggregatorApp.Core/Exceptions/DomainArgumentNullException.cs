using System;

namespace OnlineBookingAggregatorApp.Core.Exceptions
{
    public class DomainArgumentNullException : ArgumentNullException
    {
        public DomainArgumentNullException()
        {
        }

        public DomainArgumentNullException(string paramName) : base(paramName)
        {
        }

        public DomainArgumentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DomainArgumentNullException(string paramName, string message) : base(paramName, message)
        {
        }
    }
}