using System;
using System.Linq;
using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories
{
    public class CategoryCreateUpdateDtoValidator : AbstractValidator<CategoryCreateUpdateDto>
    {
        public CategoryCreateUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
            
            RuleFor(x => (long) x.BusinessArea)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(BusinessArea)).Cast<BusinessArea>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(BusinessArea)).Cast<BusinessArea>().Max());
            
            RuleFor(x => (long) x.ServiceTargetGroup)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(ServiceTargetGroup)).Cast<BusinessArea>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(ServiceTargetGroup)).Cast<BusinessArea>().Max());
        }
    }
}