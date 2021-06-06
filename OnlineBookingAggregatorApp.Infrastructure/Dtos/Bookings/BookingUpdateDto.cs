using System;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingUpdateDto
    {
        public long ClientId { get; set; }
        public long ServiceId { get; set; }
        public DateTime DateFrom { get; set; }
        public int HourFrom { get; set; }
        public int MinutesFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int HourTo { get; set; }
        public int MinutesTo { get; set; }
        public Colour? Colour { get; set; }
        public BookingState State { get; set; }
        public string Comments { get; set; }
        public long SpecialistId { get; set; }
        public bool IsFromResize { get; set; } = false;
    }
}