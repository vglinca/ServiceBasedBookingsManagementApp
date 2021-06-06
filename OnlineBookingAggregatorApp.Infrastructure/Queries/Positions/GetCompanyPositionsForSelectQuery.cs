using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Positions
{
    public class GetCompanyPositionsForSelectQuery : Query<long, IList<PositionDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCompanyPositionsForSelectQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<PositionDto>> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var positions = await _dbContext.Positions
                .AsNoTracking()
                .Where(x => x.CompanyId == input)
                .OrderBy(x => x.Name)
                .Select(x => PositionDto.From(x))
                .ToListAsync(cancellationToken);

            return positions;
        }
    }
}