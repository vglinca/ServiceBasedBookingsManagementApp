using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Categories
{
    public class DeleteCategoryCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteCategoryCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync(long input)
        {
            var category = await _dbContext.Categories.SingleByIdAsync(input);

            if (await _dbContext.Services.AnyAsync(x => x.CategoryId == category.Id))
            {
                throw new BadRequestException("Can't delete category that contains services.");
            }

            _dbContext.Categories.Remove(category);
        }
    }
}