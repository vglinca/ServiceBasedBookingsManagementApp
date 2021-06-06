using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules
{
    public class WorkScheduleDtoValidator : AbstractValidator<WorkScheduleDto>
    {
        public WorkScheduleDtoValidator()
        {
            RuleFor(x => x.WorkingHoursFrom).GreaterThanOrEqualTo(0);
            RuleFor(x => x.WorkingHoursTo)
                .GreaterThan(x => x.WorkingHoursFrom);
        }
    }
}