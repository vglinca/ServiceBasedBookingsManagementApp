using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Clients;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Clients
{
    public class ChangeClientCategoryCommand : Command<(long, ClientCategoryUpdateDto)>
    {
        private readonly AppDbContext _dbContext;

        public ChangeClientCategoryCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, ClientCategoryUpdateDto) input)
        {
            var (clientId, dto) = input;
            var client = await _dbContext.Clients.FirstByIdOrDefaultAsync(clientId);
            client.ClientCategory = dto.ClientCategory;
        }
    }
}