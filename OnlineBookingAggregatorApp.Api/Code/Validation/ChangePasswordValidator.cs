using System.ComponentModel.DataAnnotations;
using OnlineBookingAggregatorApp.Api.Models.Auth;

namespace OnlineBookingAggregatorApp.Api.Validation
{
    public class ChangePasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as EmployeeChangePasswordModel;

            return model.NewPassword.Equals(model.OldPassword)
                ? new ValidationResult(ErrorMessage, new[] {nameof(EmployeeChangePasswordModel)})
                : ValidationResult.Success;
        }
    }
}