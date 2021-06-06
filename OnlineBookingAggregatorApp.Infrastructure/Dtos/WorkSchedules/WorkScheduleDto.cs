using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules
{
    public class WorkScheduleDto
    {
        public long WorkScheduleId { get; set; }
        public IList<WeekDay> DaysOfWeek { get; set; }
        public int WorkingHoursFrom { get; set; }
        public int WorkingMinutesFrom { get; set; }
        public int WorkingHoursTo { get; set; }
        public int WorkingMinutesTo { get; set; }

        public static WorkScheduleDto From(WorkSchedule src) => new()
        {
            WorkScheduleId = src.Id,
            WorkingHoursFrom = src.WorkingHoursFrom,
            WorkingMinutesFrom = src.WorkingMinutesFrom,
            WorkingHoursTo = src.WorkingHoursTo,
            WorkingMinutesTo = src.WorkingMinutesTo
        };

        public static WorkSchedule To(WorkScheduleDto src) => new()
        {
            WorkingHoursFrom = src.WorkingHoursFrom,
            WorkingMinutesFrom = src.WorkingMinutesFrom,
            WorkingHoursTo = src.WorkingHoursTo,
            WorkingMinutesTo = src.WorkingMinutesTo
        };
    }
}