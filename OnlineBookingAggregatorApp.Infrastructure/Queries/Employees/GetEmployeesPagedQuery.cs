using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Employees
{
    public class GetEmployeesPagedQuery : Query<(long, PagedRequest), PagedResult<EmployeeDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetEmployeesPagedQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<PagedResult<EmployeeDto>> ExecuteAsync((long, PagedRequest) input, CancellationToken cancellationToken = default)
        {
            var (companyId, pagedRequest) = input;
            var employeesQuery = _dbContext.Users
                .AsNoTracking()
                .Include(x => x.Position)
                .Where(x => x.CompanyId == companyId);
            
            return await PagedResult<EmployeeDto>.From(employeesQuery, pagedRequest, EmployeeDto.From);
        }
    }
}