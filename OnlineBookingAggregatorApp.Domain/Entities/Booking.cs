using System;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Booking : Entity
    {
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Comments { get; set; }
        public long SpecialistId { get; set; }
        public User Specialist { get; set; }
        public Colour? Colour { get; set; }
        public BookingState State { get; set; }
        public Booking() {}
    }
}