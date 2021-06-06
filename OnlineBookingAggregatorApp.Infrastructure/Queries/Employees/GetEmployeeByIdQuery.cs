using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Employees
{
    public class GetEmployeeByIdQuery : Query<long, EmployeeDto>
    {
        private readonly AppDbContext _dbContext;

        public GetEmployeeByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<EmployeeDto> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var employee = await _dbContext.Users
                .AsNoTracking()
                .Include(x => x.Position)
                .FirstUserByIdAsync(input, cancellationToken);
            
            return EmployeeDto.From(employee);
        }
    }
}