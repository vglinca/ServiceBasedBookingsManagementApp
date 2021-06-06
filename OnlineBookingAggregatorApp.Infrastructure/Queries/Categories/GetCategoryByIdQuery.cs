using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Categories
{
    public class GetCategoryByIdQuery : Query<long, CategoryDto>
    {
        private readonly AppDbContext _dbContext;

        public GetCategoryByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CategoryDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var category = await _dbContext.Categories
                .AsNoTracking()
                .FirstByIdOrDefaultAsync(input, cancellationToken);
            
            return CategoryDto.From(category);
        }
    }
}