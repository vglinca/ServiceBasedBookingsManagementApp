using FluentValidation;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Notifications
{
    public class NotificationCreateDtoValidator : AbstractValidator<NotificationCreateDto>
    {
        public NotificationCreateDtoValidator()
        {
            RuleFor(x => x.Message).MaximumLength(1000);
            RuleFor(x => x.Title).MaximumLength(30);
            RuleFor(x => x.ReceiverId).GreaterThan(0);
        }
    }
}