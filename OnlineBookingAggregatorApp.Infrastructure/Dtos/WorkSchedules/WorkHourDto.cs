using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules
{
    public class WorkHourDto
    {
        public WeekDay WeekDay { get; set; }
        public int HourFrom { get; set; }
        public int MinutesFrom { get; set; }
        public int HourTo { get; set; }
        public int MinutesTo { get; set; }
    }
}