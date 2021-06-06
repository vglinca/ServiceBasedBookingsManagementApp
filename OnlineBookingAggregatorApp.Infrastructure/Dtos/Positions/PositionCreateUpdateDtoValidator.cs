using FluentValidation;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions
{
    public class PositionCreateUpdateDtoValidator : AbstractValidator<PositionCreateUpdateDto>
    {
        public PositionCreateUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}