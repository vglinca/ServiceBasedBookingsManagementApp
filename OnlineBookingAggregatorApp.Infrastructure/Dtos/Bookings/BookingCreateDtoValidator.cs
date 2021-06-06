using System;
using System.Linq;
using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingCreateDtoValidator : AbstractValidator<BookingCreateDto>
    {
        public BookingCreateDtoValidator()
        {
            RuleFor(x => x.DateFrom).GreaterThan(DateTime.Now);
            RuleFor(x => x.DateTo.Date).Equal(x => x.DateFrom.Date);
            RuleFor(x => x.Comments).MaximumLength(1000);
            RuleFor(x => x.ClientFirstName).NotEmpty().When(x => x.ClientId == 0);
            RuleFor(x => x.ClientLastName).NotEmpty().When(x => x.ClientId == 0);
            RuleFor(x => x.ClientEmail).NotEmpty().When(x => x.ClientId == 0);
            RuleFor(x => x.ClientPhone).NotEmpty().When(x => x.ClientId == 0);
            RuleFor(x => x.ClientEmail).Matches(AppConstants.Parameters.EmailRegex)
                .When(x => x.ClientId == 0);
            RuleFor(x => (long) x.Colour)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(Colour)).Cast<Colour>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(Colour)).Cast<Colour>().Max())
                .When(x => x.Colour != null);
            RuleFor(x => x.HourTo).GreaterThanOrEqualTo(x => x.HourFrom);
            RuleFor(x => x.MinutesTo)
                .GreaterThan(x => x.MinutesFrom)
                .When(x => x.HourTo == x.HourFrom);
        }
    }
}