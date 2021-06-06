namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class WorkSchedule : Entity
    {
        public int WorkingHoursFrom { get; set; }
        public int WorkingMinutesFrom { get; set; }
        public int WorkingHoursTo { get; set; }
        public int WorkingMinutesTo { get; set; }
        public User Employee { get; set; }
        public long EmployeeId { get; set; }
    }
}