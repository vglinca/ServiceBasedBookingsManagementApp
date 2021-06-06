using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Infrastructure.Settings;

namespace OnlineBookingAggregatorApp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly SmtpOptions _smtpOptions;

        public EmailService(SmtpClient smtpClient, IOptions<SmtpOptions> smtpOptions)
        {
            _smtpClient = smtpClient;
            _smtpOptions = smtpOptions.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string content)
        {
            var message = new MailMessage {From = new MailAddress(_smtpOptions.From)};
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = content;
            _smtpClient.EnableSsl = true;
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            await _smtpClient.SendMailAsync(message);
        }
    }
}