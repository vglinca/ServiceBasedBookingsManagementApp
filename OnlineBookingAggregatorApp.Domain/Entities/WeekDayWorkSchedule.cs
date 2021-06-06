using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class WeekDayWorkSchedule : Entity
    {
        public WorkSchedule WorkSchedule { get; set; }
        public long WorkScheduleId { get; set; }
        public WeekDay DayOfWeek { get; set; }
    }
}