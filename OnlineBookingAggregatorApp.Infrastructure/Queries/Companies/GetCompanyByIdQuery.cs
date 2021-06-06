using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Companies
{
    public class GetCompanyByIdQuery : Query<long, CompanyDto>
    {
        private readonly AppDbContext _dbContext;

        public GetCompanyByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CompanyDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var cmp = await _dbContext.Companies.SingleByIdOrDefaultAsync(input, cancellationToken);
            var company = await _dbContext.Companies
                .AsNoTracking()
                .Where(x => x.Id == input)
                .Select(x => CompanyDto.From(x))
                .SingleOrDefaultAsync(cancellationToken);
            
            return company;
        }
    }
}