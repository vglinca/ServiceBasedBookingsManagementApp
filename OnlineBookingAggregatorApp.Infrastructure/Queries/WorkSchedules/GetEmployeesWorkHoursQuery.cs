using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.WorkSchedules
{
    public class GetEmployeesWorkHoursQuery : Query<long[], IList<WeekDayWorkHoursDto>>
    {
        private const int Columns = 7;
        private const int Rows = 96;
        private readonly AppDbContext _dbContext;

        public GetEmployeesWorkHoursQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<WeekDayWorkHoursDto>> ExecuteAsync(long[] employeeIds, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Users
                .AsNoTracking()
                .Include(x => x.WorkSchedules)
                .Where(x => employeeIds.Contains(x.Id))
                .SelectMany(x => x.WorkSchedules)
                .ToListAsync(cancellationToken)
                .ContinueWith(async ws =>
                {
                    var scheduleIds = (await ws).Select(x => x.Id).ToList();
                    var weekDayWorkSchedules = (await _dbContext.WeekDayWorkSchedules
                            .AsNoTracking()
                            .Include(x => x.WorkSchedule)
                            .Where(x => scheduleIds.Contains(x.WorkScheduleId))
                            .ToListAsync(cancellationToken))
                        .GroupBy(x => x.WorkSchedule.EmployeeId)
                        .Select(x => new WeekDayWorkHoursDto
                        {
                            EmployeeId = x.Key,
                            WorkHours = x.Select(y => new WorkHourDto
                            {
                                WeekDay = y.DayOfWeek,
                                HourFrom = y.WorkSchedule.WorkingHoursFrom,
                                MinutesFrom = y.WorkSchedule.WorkingMinutesFrom,
                                HourTo = y.WorkSchedule.WorkingHoursTo,
                                MinutesTo = y.WorkSchedule.WorkingMinutesTo
                            }).ToList()
                        })
                        .ToList();

                    return weekDayWorkSchedules;
                }, cancellationToken)
                .Unwrap();

            foreach (var weekDayWorkSchedule in result)
            {
                var workHoursMatrix = new bool[Rows][];
                for (var i = 0; i < Rows; i++)
                {
                    workHoursMatrix[i] = new bool[Columns];
                    for (var j = 0; j < Columns; j++)
                    {
                        workHoursMatrix[i][j] = false;
                    }
                }

                foreach (var workHours in weekDayWorkSchedule.WorkHours)
                {
                    var indexFrom = workHours.HourFrom * 4 + workHours.MinutesFrom / 15;
                    var indexTo = workHours.HourTo * 4 + workHours.MinutesTo / 15;

                    for (var i = indexFrom; i <= indexTo; i++)
                    {
                        workHoursMatrix[i][(int) workHours.WeekDay - 1] = true;
                    }
                }

                weekDayWorkSchedule.WorkHoursMatrix = workHoursMatrix;
            }

            return result;
        }
    }
}