using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Categories
{
    public class CanDeleteCategoryQuery : Query<long, bool>
    {
        private readonly AppDbContext _dbContext;

        public CanDeleteCategoryQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<bool> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            await _dbContext.Categories.AssertEntityExistsAsync(input);

            var contains = await _dbContext.Services
                .AsNoTracking()
                .AnyAsync(x => x.CategoryId == input, cancellationToken);

            return contains;
        }
    }
}