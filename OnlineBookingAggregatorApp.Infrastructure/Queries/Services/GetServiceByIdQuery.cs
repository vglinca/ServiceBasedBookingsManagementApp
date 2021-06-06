using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Services
{
    public class GetServiceByIdQuery : Query<long, ServiceDto>
    {
        private readonly AppDbContext _dbContext;

        public GetServiceByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ServiceDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var service = await _dbContext.Services
                .Include(x => x.Category)
                .Include(x => x.Bookings)
                .SingleByIdAsync(input, cancellationToken);
            
            var employeeIds = await _dbContext.ServiceEmployees
                .AsNoTracking()
                .Where(x => x.ServiceId == service.Id)
                .Select(x => x.EmployeeId)
                .ToListAsync(cancellationToken);

            var dto = ServiceDto.From(service);
            dto.EmployeeIds = employeeIds;
            
            return dto;
        }
    }
}