using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Clients
{
    public class GetClientByIdQuery : Query<long, ClientDto>
    {
        private readonly AppDbContext _dbContext;

        public GetClientByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ClientDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var client = await _dbContext.Clients
                .AsNoTracking()
                .SingleByIdAsync(input, cancellationToken);
            
            return ClientDto.From(client);
        }
    }
}