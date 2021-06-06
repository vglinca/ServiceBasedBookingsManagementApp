using System.ComponentModel.DataAnnotations;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Api.Models.Auth
{
    public class LoginModel
    {
        [Required]
        [RegularExpression(AppConstants.Parameters.EmailRegex)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}