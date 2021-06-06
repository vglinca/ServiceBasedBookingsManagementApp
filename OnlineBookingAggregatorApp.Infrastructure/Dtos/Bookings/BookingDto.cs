using System;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingDto
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AdditionalPhone { get; set; }
        public long ServiceId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Comments { get; set; }
        public long SpecialistId { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public BookingState State { get; set; }
        public DateTimeOffset? ClientBirthDate { get; set; }
        public BookingColourDto Colour { get; set; }
        public string Specialist { get; set; }

        public static BookingDto From(Booking src) => new BookingDto
        {
            Id = src.Id,
            ClientId = src.ClientId,
            FirstName = src.Client.FirstName,
            LastName = src.Client.LastName,
            Email = src.Client.Email,
            Phone = src.Client.PhoneNumber,
            AdditionalPhone = src.Client.AdditionalPhoneNumber,
            ServiceId = src.ServiceId,
            DateFrom = src.DateFrom,
            DateTo = src.DateTo,
            Comments = src.Comments,
            SpecialistId = src.SpecialistId,
            ClientCategory = src.Client.ClientCategory,
            ClientBirthDate = src.Client.DateOfBirth,
            Colour = BookingColourDto.From(src.Colour),
            Specialist = $"{src.Specialist.FirstName} {src.Specialist.LastName}",
            State = src.State
        };
    }
}