using System.Threading.Tasks;

namespace OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string content);
    }
}