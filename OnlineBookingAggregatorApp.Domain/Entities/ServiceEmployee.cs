namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class ServiceEmployee : Entity
    {
        public long EmployeeId { get; set; }
        public User Employee { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
    }
}