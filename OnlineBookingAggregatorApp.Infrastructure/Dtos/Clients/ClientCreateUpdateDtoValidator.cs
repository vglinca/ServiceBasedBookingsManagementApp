using System;
using System.Linq;
using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients
{
    public class ClientCreateUpdateDtoValidator : AbstractValidator<ClientCreateUpdateDto>
    {
        public ClientCreateUpdateDtoValidator()
        {
            RuleFor(x => x.LastName).MaximumLength(40).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(40).NotEmpty();
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(40)
                .Matches(AppConstants.Parameters.PhoneRegex)
                .NotEmpty();
            RuleFor(x => x.AdditionalPhoneNumber)
                .MaximumLength(40)
                .Matches(AppConstants.Parameters.PhoneRegex)
                .When(x => !string.IsNullOrWhiteSpace(x.AdditionalPhoneNumber));
            RuleFor(x => x.Email)
                .MaximumLength(100)
                .Matches(AppConstants.Parameters.EmailRegex)
                .NotEmpty();
            RuleFor(x => (long) x.ClientCategory)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(ClientCategory)).Cast<ClientCategory>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(ClientCategory)).Cast<ClientCategory>().Max());
            RuleFor(x => (long?) x.Gender)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(Gender)).Cast<Gender>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(Gender)).Cast<Gender>().Max())
                .When(x => x.Gender != null && x.Gender > 0);
            RuleFor(x => x.Comments).MaximumLength(500);
        }
    }
}