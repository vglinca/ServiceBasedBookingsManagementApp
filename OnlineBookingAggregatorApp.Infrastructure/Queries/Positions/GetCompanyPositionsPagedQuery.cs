using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Positions
{
    public class GetCompanyPositionsPagedQuery : Query<(long, PagedRequest), PagedResult<PositionDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCompanyPositionsPagedQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<PagedResult<PositionDto>> ExecuteAsync((long, PagedRequest) input, CancellationToken cancellationToken = default)
        {
            var (companyId, pagedRequest) = input;
            var positionsQuery = _dbContext.Positions.AsNoTracking()
                .Where(x => x.CompanyId == companyId);
            
            return await PagedResult<PositionDto>.From(positionsQuery, pagedRequest, PositionDto.From);
        }
    }
}