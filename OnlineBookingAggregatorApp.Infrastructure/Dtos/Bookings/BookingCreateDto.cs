using System;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingCreateDto
    {
        public long ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public long ServiceId { get; set; }
        public DateTime DateFrom { get; set; }
        public int HourFrom { get; set; }
        public int MinutesFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int HourTo { get; set; }
        public int MinutesTo { get; set; }
        public Colour? Colour { get; set; }
        public string Comments { get; set; }
        public long SpecialistId { get; set; }
        public Gender? Gender { get; set; }
        public DateTimeOffset? ClientBirthDate { get; set; }
    }
}