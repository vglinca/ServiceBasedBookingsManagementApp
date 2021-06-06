using System.ComponentModel.DataAnnotations;
using OnlineBookingAggregatorApp.Api.Validation;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Api.Models.Auth
{
    [ChangePasswordValidator(ErrorMessage = AppConstants.TextMessages.OldAndNewPasswordValidationError)]
    public class EmployeeChangePasswordModel
    {
        [Required]
        [RegularExpression(AppConstants.Parameters.EmailRegex)]
        public string Email { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}