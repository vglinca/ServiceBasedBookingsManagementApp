using System;
using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Client : Entity
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
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public Client() {}
        public Client(string firstName, string lastName, string phoneNumber, string additionalPhoneNumber, string email, 
            ClientCategory clientCategory, Gender? gender, DateTimeOffset? dateOfBirth, string comments, long companyId)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            AdditionalPhoneNumber = additionalPhoneNumber;
            Email = email;
            ClientCategory = clientCategory;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Comments = comments;
            CompanyId = companyId;
        }
    }
}