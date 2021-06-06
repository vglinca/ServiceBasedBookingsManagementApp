using System.ComponentModel.DataAnnotations;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Api.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(AppConstants.Parameters.EmailRegex)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}