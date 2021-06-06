using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies
{
    public class CompanyCreateDtoValidator : AbstractValidator<CompanyCreateDto>
    {
        public CompanyCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Address.City).NotEmpty();
            RuleFor(x => x.Address.Country).NotEmpty();
            RuleFor(x => x.Email).Matches(AppConstants.Parameters.EmailRegex);
            RuleFor(x => x.Email).NotEmpty()
                .When(x => x.CompanyType == CompanyType.JuridicalPerson);
        }
    }
}