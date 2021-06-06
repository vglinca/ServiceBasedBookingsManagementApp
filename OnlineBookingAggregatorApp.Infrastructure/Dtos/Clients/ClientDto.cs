using System;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients
{
    public class ClientDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalPhoneNumber { get; set; }
        public string Email { get; set; }
        public string ClientCategory { get; set; }
        public ClientCategory ClientCategoryId { get; set; }
        public string Gender { get; set; }
        public Gender? GenderId { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string Comments { get; set; }

        public static ClientDto From(Client src) => new()
        {
            Id = src.Id,
            FirstName = src.FirstName,
            LastName = src.LastName,
            PhoneNumber = src.PhoneNumber,
            AdditionalPhoneNumber = src.AdditionalPhoneNumber,
            Email = src.Email,
            ClientCategoryId = src.ClientCategory,
            ClientCategory = Enum.GetName(typeof(ClientCategory), src.ClientCategory),
            Gender = src.Gender != null ? Enum.GetName(typeof(Gender), src.Gender) : "N/A",
            GenderId = src.Gender,
            DateOfBirth = src.DateOfBirth,
            Comments = src.Comments
        };
    }
}