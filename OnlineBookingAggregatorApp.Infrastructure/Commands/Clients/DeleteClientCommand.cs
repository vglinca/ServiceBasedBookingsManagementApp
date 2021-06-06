using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Clients
{
    public class DeleteClientCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteClientCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync(long clientId)
        {
            var client = await _dbContext.Clients.SingleByIdOrDefaultAsync(clientId);
            _dbContext.Clients.Remove(client);
        }
    }
}