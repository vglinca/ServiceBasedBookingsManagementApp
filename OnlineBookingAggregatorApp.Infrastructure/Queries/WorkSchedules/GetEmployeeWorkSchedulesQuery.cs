using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.WorkSchedules
{
    public class GetEmployeeWorkSchedulesQuery : Query<long, IList<WorkScheduleDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetEmployeeWorkSchedulesQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public override async Task<IList<WorkScheduleDto>> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.WorkSchedules
                .AsNoTracking()
                .Where(x => x.EmployeeId == input)
                .Select(x => WorkScheduleDto.From(x))
                .ToListAsync(cancellationToken);

            var daysOfWeek = await _dbContext.WeekDayWorkSchedules.AsNoTracking()
                .Where(x => result.Select(y => y.WorkScheduleId).Contains(x.WorkScheduleId))
                .Select(x => new {x.WorkScheduleId, x.DayOfWeek})
                .ToListAsync(cancellationToken);

            foreach (var dto in result)
            {
                var daysOfWeekForDto = daysOfWeek
                    .Where(x => x.WorkScheduleId == dto.WorkScheduleId)
                    .Select(x => x.DayOfWeek)
                    .ToList();

                dto.DaysOfWeek = daysOfWeekForDto;
            }

            return result;
        }
    }
}