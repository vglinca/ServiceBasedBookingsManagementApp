using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Positions
{
    public class AddPositionCommand : Command<(long, PositionCreateUpdateDto), Position>
    {
        private readonly AppDbContext _dbContext;

        public AddPositionCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Position> ExecuteAsync((long, PositionCreateUpdateDto) input)
        {
            var (companyId, dto) = input;
            var company = await _dbContext.Companies.FirstByIdOrDefaultAsync(companyId);
            var position = new Position(dto.Name, dto.Description, company.Id, company);
            await _dbContext.Positions.AddAsync(position);

            return position;
        }
    }
}