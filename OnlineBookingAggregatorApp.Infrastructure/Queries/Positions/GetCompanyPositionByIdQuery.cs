using System.Threading;
using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Positions
{
    public class GetPositionByIdQuery : Query<long, PositionDto>
    {
        private readonly AppDbContext _dbContext;

        public GetPositionByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<PositionDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var position = await _dbContext.Positions.SingleByIdAsync(input, cancellationToken);
            return PositionDto.From(position);
        }
    }
}