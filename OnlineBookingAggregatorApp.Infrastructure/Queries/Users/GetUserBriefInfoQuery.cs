using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Users
{
    public class GetUserBriefInfoQuery : Query<long, EmployeeForSelectDto>
    {
        private readonly AppDbContext _dbContext;

        public GetUserBriefInfoQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<EmployeeForSelectDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .Include(x => x.ServiceEmployees)
                .FirstUserByIdAsync(input, cancellationToken);
            
            return EmployeeForSelectDto.From(user);
        }
    }
}