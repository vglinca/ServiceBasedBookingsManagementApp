using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Services
{
    public class GetServicesForSelectQuery : Query<long, IList<ServiceForSelectDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetServicesForSelectQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<ServiceForSelectDto>> ExecuteAsync(long companyId, CancellationToken cancellationToken = default)
        {
            var services = await _dbContext.Services.AsNoTracking()
                .Where(x => x.Category.CompanyId == companyId)
                .Select(x => ServiceForSelectDto.From(x))
                .ToListAsync(cancellationToken);
            
            return services;
        }
    }
}