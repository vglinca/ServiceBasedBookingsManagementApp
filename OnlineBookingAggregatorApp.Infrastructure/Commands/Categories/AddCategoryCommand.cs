using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Categories
{
    public class AddCategoryCommand : Command<(long, CategoryCreateUpdateDto), Category>
    {
        private readonly AppDbContext _dbContext;

        public AddCategoryCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Category> ExecuteAsync((long, CategoryCreateUpdateDto) input)
        {
            var (companyId, categoryDto) = input;
            await _dbContext.Companies.AssertEntityExistsAsync(companyId);

            var category = new Category
            {
                Name = categoryDto.Name,
                BusinessArea = categoryDto.BusinessArea,
                CompanyId = companyId,
                ServiceTargetGroup = categoryDto.ServiceTargetGroup
            };

            await _dbContext.Categories.AddAsync(category);

            return category;
        }
    }
}