using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Positions
{
    public class DeletePositionCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeletePositionCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync(long input)
        {
            var usersWithTargetPosition = _dbContext.Users.AsNoTracking()
                .Where(x => x.PositionId == input);
            
            if (await usersWithTargetPosition.AnyAsync())
            {
                throw new BadRequestException($"Can not delete position with id {input}. Remove related users first.");
            }

            var position = await _dbContext.Positions.FirstByIdOrDefaultAsync(input);
            _dbContext.Positions.Remove(position);
        }
    }
}