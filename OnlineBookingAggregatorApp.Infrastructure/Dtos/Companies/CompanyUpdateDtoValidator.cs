using FluentValidation;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies
{
    public class CompanyUpdateDtoValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches(AppConstants.Parameters.EmailRegex);
            RuleFor(x => x.BusinessAreas).NotEmpty();
        }
    }
}