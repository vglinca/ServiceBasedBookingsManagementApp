using System;
using System.Linq;
using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees
{
    public class EmployeeCreateUpdateDtoValidator : AbstractValidator<EmployeeCreateUpdateDto>
    {
        public EmployeeCreateUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty()
                .Matches(AppConstants.Parameters.EmailRegex);
            RuleFor(x => x.Phone).Matches(AppConstants.Parameters.PhoneRegex)
                .NotEmpty();
            RuleFor(x => x.WorkSchedules).NotEmpty().NotNull()
                .WithMessage("At least one work schedule must be provided.");
            RuleForEach(x => x.WorkSchedules)
                .SetValidator(new WorkScheduleDtoValidator());
            RuleFor(x => (long) x.RoleId)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(SystemRole)).Cast<SystemRole>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(SystemRole)).Cast<SystemRole>().Max());
        }
    }
}