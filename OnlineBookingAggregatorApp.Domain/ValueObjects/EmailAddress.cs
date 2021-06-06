using System.Text.RegularExpressions;
using OnlineBookingAggregatorApp.Core.Exceptions;
using ValueOf;

namespace OnlineBookingAggregatorApp.Domain.ValueObjects
{
    public class EmailAddress : ValueOf<string, EmailAddress>
    {
        private const string EmailRegex = @"^(?!.*\.{2})(?:[A-Za-z0-9_-]+(?:\.[A-Za-z0-9_-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)@(?:(?:[A-Za-z0-9-](?:[A-Za-z0-9-]*[A-Za-z0-9-])?\.)+[A-Za-z0-9-](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])+$";
        private static Match GetMatch(string email) => Regex.Match(email.Trim().ToLower(), EmailRegex);
        protected override void Validate()
        {
            if (Value == null || !GetMatch(Value).Success)
            {
                throw new DomainArgumentException($"{nameof(EmailAddress)}({Value} : not a valid format.");
            }
        }
    }
}