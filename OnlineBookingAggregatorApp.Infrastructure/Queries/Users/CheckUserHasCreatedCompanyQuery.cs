using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Users
{
    public class CheckUserHasCreatedCompanyQuery : Query<long, bool>
    {
        private readonly AppDbContext _dbContext;

        public CheckUserHasCreatedCompanyQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<bool> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Users.SingleUserByIdAsync(input);
            var company = await _dbContext.Companies
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.CreatedById == input, cancellationToken);

            return company != null || user.SystemRole != SystemRole.CompanyAdmin;
        }
    }
}