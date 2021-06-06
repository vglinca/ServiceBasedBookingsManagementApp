using System;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingPagedDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public string SpecialistFirstName { get; set; }
        public string SpecialistLastName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public BookingState StateId { get; set; }
        public string State { get; set; }

        public static BookingPagedDto From(Booking src)
        {
            var stateEntity = BookingStateEntityFactory.Instance.Get(src.State);
            var booking = new BookingPagedDto
            {
                Id = src.Id,
                FirstName = src.Client.FirstName,
                LastName = src.Client.LastName,
                Email = src.Client.Email,
                Phone = src.Client.PhoneNumber,
                Service = src.Service.Name,
                SpecialistFirstName = src.Specialist.FirstName,
                SpecialistLastName = src.Specialist.LastName,
                DateFrom = src.DateFrom,
                DateTo = src.DateTo,
                StateId = src.State,
                State = stateEntity.Name
            };

            return booking;
        }
    }
}