using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Clients
{
    public class GetClientsPagedQuery : Query<(long, PagedRequest), PagedResult<ClientDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetClientsPagedQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<PagedResult<ClientDto>> ExecuteAsync((long, PagedRequest) input, CancellationToken cancellationToken = default)
        {
            var (companyId, pagedRequest) = input;

            await _dbContext.Companies.AssertEntityExistsAsync(companyId);
            
            var clientsQuery = _dbContext.Clients
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId);
            
            return await PagedResult<ClientDto>.From(clientsQuery, pagedRequest, ClientDto.From);
        }
    }
}