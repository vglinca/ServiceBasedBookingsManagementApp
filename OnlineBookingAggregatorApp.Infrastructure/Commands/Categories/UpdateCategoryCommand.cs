using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Categories
{
    public class UpdateCategoryCommand : Command<(long, CategoryCreateUpdateDto)>
    {
        private readonly AppDbContext _dbContext;

        public UpdateCategoryCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, CategoryCreateUpdateDto) input)
        {
            var (categoryId, dto) = input;
            var category = await _dbContext.Categories.SingleByIdAsync(categoryId);

            if (await _dbContext.Services.AnyAsync(x => x.CategoryId == categoryId))
            {
                throw new BadRequestException("Can't update category that contains services.");
            }

            category.Name = dto.Name;
            category.BusinessArea = dto.BusinessArea;
            category.ServiceTargetGroup = dto.ServiceTargetGroup;
        }
    }
}