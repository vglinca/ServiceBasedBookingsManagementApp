using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Categories
{
    public class CheckCategoryNameIsUniqueQuery : Query<(string, long?), bool>
    {
        private readonly AppDbContext _dbContext;

        public CheckCategoryNameIsUniqueQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<bool> ExecuteAsync((string, long?) input, CancellationToken cancellationToken = default)
        {
            var (name, id) = input;
            var unique = !(await _dbContext.Categories
                .AsNoTracking()
                .AnyAsync(x => x.Name.Equals(name) && x.Id != id, cancellationToken));

            return unique;
        }
    }
}