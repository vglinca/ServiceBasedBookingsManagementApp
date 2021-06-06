using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Services
{
    public class ServiceNameUniqueQuery : Query<(string, long?), bool>
    {
        private readonly AppDbContext _dbContext;

        public ServiceNameUniqueQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<bool> ExecuteAsync((string, long?) input, CancellationToken cancellationToken = default)
        {
            var (name, id) = input;
            var unique = ! await _dbContext.Services.AsNoTracking()
                .AnyAsync(x => x.Name.Equals(name) && x.Id != id, cancellationToken);

            return unique;
        }
    }
}