
namespace OnlineBookingAggregatorApp.Infrastructure.Constants
{
    public static class AppConstants
    {
        public static class Parameters
        {
            public const string EmailRegex = @"^(?!.*\.{2})(?:[A-Za-z0-9_-]+(?:\.[A-Za-z0-9_-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)@(?:(?:[A-Za-z0-9-](?:[A-Za-z0-9-]*[A-Za-z0-9-])?\.)+[A-Za-z0-9-](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])+$";
            public const string PhoneRegex = @"^[\+0-9]+$";
            public const string FirstName = nameof(FirstName);
            public const string LastName = nameof(LastName);
            public const string CompanyId = nameof(CompanyId);
            public const string TraceId = nameof(TraceId);
            public const string AllowOrigin = nameof(AllowOrigin);
            public const string Authorization = nameof(Authorization);
            public const string Bearer = nameof(Bearer);
            public const string JwtToken = nameof(JwtToken);
            public const string TokenExpired = nameof(TokenExpired);
            public const string UserPolicies = nameof(UserPolicies);
            public const string UserId = nameof(UserId);
            public const string DateOfBirth = nameof(DateOfBirth);
            public const string HubEndpoint = "/notificationsHub";
        }
        
        public static class TextMessages
        {
            public const string OldAndNewPasswordValidationError = "New password and old password should be different.";
            public const string InvalidAccessToken = "Invalid Access Token";
            public const string ValidationProblemTitle = "One or more validation problems has occured.";
            public const string ValidationProblemDetails = "See the 'errors' property for details.";
            public const string WrongCredentialsMessage = "Wrong credentials.";
            public const string Status500Message = "An unexpected fault happened. Try again later.";
            public const string ErrorMessageContentType = "application/problem+json";
            public const string SwaggerDocName = "Online Booking Aggregator API";
            public const string SwaggerDocVersion = "1.0";
        }
    }
}