using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Employees
{
    public class GetEmployeesForSelectQuery : Query<long, IList<EmployeeForSelectDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetEmployeesForSelectQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<EmployeeForSelectDto>> ExecuteAsync(long companyId, CancellationToken cancellationToken = default)
        {
            var employees = await _dbContext.Users
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new EmployeeForSelectDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PositionId = x.PositionId,
                    ServicesIds = x.ServiceEmployees.Select(y => y.ServiceId).ToList()
                })
                .ToListAsync(cancellationToken);

            return employees;
        }
    }
}