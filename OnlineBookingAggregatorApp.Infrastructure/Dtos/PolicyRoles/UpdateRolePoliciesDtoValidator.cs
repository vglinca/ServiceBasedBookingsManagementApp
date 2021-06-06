using System;
using System.Linq;
using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles
{
    public class UpdateRolePoliciesDtoValidator : AbstractValidator<UpdateRolePoliciesDto>
    {
        public UpdateRolePoliciesDtoValidator()
        {
            RuleFor(x => x.RoleId)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(SystemRole)).Cast<SystemRole>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(SystemRole)).Cast<SystemRole>().Max());
            RuleFor(x => x.Policies).NotEmpty();
        }
    }
}