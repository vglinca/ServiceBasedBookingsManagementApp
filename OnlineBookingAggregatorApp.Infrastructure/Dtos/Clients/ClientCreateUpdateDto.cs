using System;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients
{
    public class ClientCreateUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalPhoneNumber { get; set; }
        public string Email { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public Gender? Gender { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string Comments { get; set; }
    }
}