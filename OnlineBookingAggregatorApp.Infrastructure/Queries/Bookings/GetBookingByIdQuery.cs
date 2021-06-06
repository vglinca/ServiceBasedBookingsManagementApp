using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Bookings
{
    public class GetBookingByIdQuery : Query<long, BookingDto>
    {
        private readonly AppDbContext _dbContext;

        public GetBookingByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<BookingDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var booking = await _dbContext.Bookings
                .AsNoTracking()
                .Include(x => x.Client)
                .Include(x => x.Specialist)
                .FirstByIdOrDefaultAsync(input, cancellationToken);
            return BookingDto.From(booking);
        }
    }
}