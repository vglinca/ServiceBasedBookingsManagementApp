using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Users
{
    public class CheckUserEmailUniqueQuery : Query<string, bool>
    {
        private readonly AppDbContext _dbContext;

        public CheckUserEmailUniqueQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<bool> ExecuteAsync(string input, CancellationToken cancellationToken = default)
        {
            var emailExists = await _dbContext.Users
                .AsNoTracking()
                .AnyAsync(x => x.Email.Equals(input), cancellationToken);
            
            return !emailExists;
        }
    }
}