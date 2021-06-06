namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Notification : Entity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public long ReceiverId { get; set; }
    }
}