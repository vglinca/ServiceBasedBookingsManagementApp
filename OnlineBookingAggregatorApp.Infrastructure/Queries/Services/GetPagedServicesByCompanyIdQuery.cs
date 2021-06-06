using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

// ReSharper disable MemberCanBePrivate.Global

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Services
{
    public class GetPagedServicesByCompanyIdQuery : Query<(long, PagedRequest), PagedResult<ServiceDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetPagedServicesByCompanyIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<PagedResult<ServiceDto>> ExecuteAsync((long, PagedRequest) input, CancellationToken cancellationToken = default)
        {
            var (companyId, pagedRequest) = input;
            await _dbContext.Companies.AssertEntityExistsAsync(companyId);
            var servicesQuery = _dbContext.Services
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Bookings)
                .Where(s => s.Category.CompanyId == companyId);
            
            return await PagedResult<ServiceDto>.From(servicesQuery, pagedRequest, ServiceDto.From);
        }
    }
}