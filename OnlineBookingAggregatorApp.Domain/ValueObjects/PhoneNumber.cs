using System.Text.RegularExpressions;
using OnlineBookingAggregatorApp.Core.Exceptions;
using ValueOf;

namespace OnlineBookingAggregatorApp.Domain.ValueObjects
{
    public class PhoneNumber : ValueOf<string, PhoneNumber>
    {
        private const string PhoneRegex = @"^[\+0-9]+$";
        private static Match GetMatch(string phoneNumber) => 
            Regex.Match(phoneNumber.Replace(" ", ""), PhoneRegex);

        protected override void Validate()
        {
            if (Value == null || !GetMatch(Value).Success)
            {
                throw new DomainArgumentException($"{nameof(PhoneNumber)}({Value} : not a valid format.");
            }
        }
    }
}