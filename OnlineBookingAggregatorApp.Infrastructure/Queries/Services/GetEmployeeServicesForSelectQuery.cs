using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Services
{
    public class GetEmployeeServicesForSelectQuery : Query<long, IList<ServiceForSelectDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetEmployeeServicesForSelectQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<ServiceForSelectDto>> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            await _dbContext.Users.AssertUserExistsAsync(input, cancellationToken);
            var services = await _dbContext.ServiceEmployees
                .AsNoTracking()
                .Where(x => x.EmployeeId.Equals(input))
                .Select(x => ServiceForSelectDto.From(x.Service))
                .ToListAsync(cancellationToken);

            return services;
        }
    }
}