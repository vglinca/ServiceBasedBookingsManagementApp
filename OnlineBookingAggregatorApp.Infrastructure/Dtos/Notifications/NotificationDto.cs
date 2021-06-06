using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Notifications
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public long ReceiverId { get; set; }

        public static NotificationDto From(Notification src) => new()
        {
            Id = src.Id,
            Title = src.Title,
            Message = src.Message,
            ReceiverId = src.ReceiverId
        };
    }
}