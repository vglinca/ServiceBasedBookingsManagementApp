using System;

namespace OnlineBookingAggregatorApp.Core.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string msg) : base(msg)
        {
            
        }
    }
}