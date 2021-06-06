using System.Collections.Generic;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules
{
    public class WeekDayWorkHoursDto
    {
        public long EmployeeId { get; set; }
        public IList<WorkHourDto> WorkHours { get; set; }
        public bool[][] WorkHoursMatrix { get; set; }
    }
}