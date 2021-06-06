using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Notifications;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Notifications
{
    public class CreateNotificationCommand : Command<NotificationCreateDto, Notification>
    {
        private readonly AppDbContext _dbContext;

        public CreateNotificationCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Notification> ExecuteAsync(NotificationCreateDto input)
        {
            var notification = new Notification
            {
                Message = input.Message,
                Title = input.Title,
                ReceiverId = input.ReceiverId
            };

            await _dbContext.Notifications.AddAsync(notification);

            return notification;
        }
    }
}