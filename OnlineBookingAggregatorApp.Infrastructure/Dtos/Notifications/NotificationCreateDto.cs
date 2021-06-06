namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Notifications
{
    public class NotificationCreateDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public long ReceiverId { get; set; }
    }
}