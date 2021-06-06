using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Categories
{
    public class GetCategoriesBriefQuery : Query<long, IList<CategoryBriefDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCategoriesBriefQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<CategoryBriefDto>> ExecuteAsync(long companyId, CancellationToken cancellationToken = default)
        {
            await _dbContext.Companies.AssertEntityExistsAsync(companyId);
            
            var categories = await _dbContext.Categories
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId)
                .Select(x => new CategoryBriefDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
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

            return categories;
        }
    }
}