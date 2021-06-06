using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Positions
{
    public class UpdatePositionCommand : Command<(long, PositionCreateUpdateDto)>
    {
        private readonly AppDbContext _dbContext;

        public UpdatePositionCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, PositionCreateUpdateDto) input)
        {
            var (positionId, dto) = input;
            var position = await _dbContext.Positions.FirstByIdOrDefaultAsync(positionId);

            position.Name = dto.Name;
            position.Description = dto.Description;
        }
    }
}