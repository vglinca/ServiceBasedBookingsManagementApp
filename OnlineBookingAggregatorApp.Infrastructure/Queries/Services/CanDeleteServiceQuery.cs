using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Services
{
    public class CanDeleteServiceQuery : Query<long, bool>
    {
        private readonly AppDbContext _dbContext;

        public CanDeleteServiceQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<bool> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var containsBookings = await _dbContext.Bookings
                .AsNoTracking()
                .AnyAsync(x => x.ServiceId == input, cancellationToken);

            return !containsBookings;
        }
    }
}