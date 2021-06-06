using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Bookings
{
    public class GetBookingsPagedQuery : Query<(long, PagedRequest), PagedResult<BookingPagedDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetBookingsPagedQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public override async Task<PagedResult<BookingPagedDto>> ExecuteAsync((long, PagedRequest) input, CancellationToken cancellationToken = default)
        {
            var (companyId, request) = input;
            var query = _dbContext.Bookings
                .AsNoTracking()
                .Include(x => x.Client)
                .Include(x => x.Service)
                .Include(x => x.Specialist)
                .Where(x => x.Service.Category.CompanyId == companyId);

            var result = await PagedResult<BookingPagedDto>.From(query, request, BookingPagedDto.From);
            return result;
        }
    }
}