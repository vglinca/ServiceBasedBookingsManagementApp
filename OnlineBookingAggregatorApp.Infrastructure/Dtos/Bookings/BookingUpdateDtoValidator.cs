using System;
using System.Data;
using System.Linq;
using FluentValidation;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingUpdateDtoValidator : AbstractValidator<BookingUpdateDto>
    {
        public BookingUpdateDtoValidator()
        {
            RuleFor(x => x.DateFrom).GreaterThan(DateTime.Now);
            RuleFor(x => x.DateTo.Date).Equal(x => x.DateFrom.Date);
            RuleFor(x => x.Comments).MaximumLength(1000);
            RuleFor(x => x.ClientId).GreaterThan(0);
            RuleFor(x => (long) x.Colour)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(Colour)).Cast<Colour>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(Colour)).Cast<Colour>().Max())
                .When(x => x.Colour != null);
            RuleFor(x => (long) x.State)
                .GreaterThanOrEqualTo((long) Enum.GetValues(typeof(BookingState)).Cast<BookingState>().Min())
                .LessThanOrEqualTo((long) Enum.GetValues(typeof(BookingState)).Cast<BookingState>().Max());
            RuleFor(x => x.HourTo).GreaterThanOrEqualTo(x => x.HourFrom);
            RuleFor(x => x.MinutesTo)
                .GreaterThan(x => x.MinutesFrom)
                .When(x => x.HourTo == x.HourFrom);
        }
    }
}