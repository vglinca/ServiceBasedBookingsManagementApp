using FluentValidation;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Services
{
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Service title must be specified.");
            RuleFor(s => s.Name).MaximumLength(100)
                .WithMessage("Service title length shouldn't be greater than 100 characters.");
            RuleFor(s => s.Description).MaximumLength(2000)
                .WithMessage("Service title length shouldn't be greater than 2000 characters.");
        }
    }
}