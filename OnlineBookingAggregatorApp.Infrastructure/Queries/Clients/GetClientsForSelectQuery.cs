using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Clients
{
    public class GetClientsForSelectQuery : Query<long, IList<ClientForSelectDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetClientsForSelectQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<ClientForSelectDto>> ExecuteAsync(long companyId, CancellationToken cancellationToken = default)
        {
            var clients = await _dbContext.Clients
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId)
                .Select(x => ClientForSelectDto.From(x))
                .ToListAsync(cancellationToken);

            return clients;
        }
    }
}