using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Categories
{
    public class GetCategoriesPagedByCompanyIdQuery : Query<(long, PagedRequest), PagedResult<CategoryDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCategoriesPagedByCompanyIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<PagedResult<CategoryDto>> ExecuteAsync((long, PagedRequest) input, CancellationToken cancellationToken = default)
        {
            var (companyId, pagedRequest) = input;
            await _dbContext.Companies.AssertEntityExistsAsync(companyId);

            var categories = await _dbContext.Categories
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId)
                .Select(x => CategoryDto.From(x))
                .ToListAsync(cancellationToken)
                .ContinueWith(async categoriesTask =>
                {
                    var result = await categoriesTask;
                    foreach (var category in result)
                    {
                        category.TotalServices = await _dbContext.Services
                            .AsNoTracking()
                            .CountAsync(x => x.CategoryId == category.Id, cancellationToken);
                    }

                    return result;
                }, cancellationToken)
                .Unwrap();

            var result = PagedResult<CategoryDto>.From(categories.AsQueryable(), pagedRequest);
            
            return result;
        }
    }
}