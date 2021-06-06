using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Roles
{
    public class GetRolesWithPoliciesQuery : Query<IList<RolePoliciesDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetRolesWithPoliciesQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<RolePoliciesDto>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var policyRoles = (await _dbContext.PolicyRoles
                    .AsNoTracking()
                    .ToListAsync(cancellationToken))
                .GroupBy(x => x.Role)
                .Select(x => new RolePoliciesDto
                {
                    RoleId = (long) x.Key,
                    RoleName = Enum.GetName(typeof(SystemRole), x.Key),
                    Policies = x.Select(y => new PolicyDto
                    {
                        PolicyId = (long) y.Policy,
                        Policy = Enum.GetName(typeof(Policy), y.Policy),
                        IsSetByDefault = y.IsSetByDefault
                    }).ToList()
                }).ToList();

            return policyRoles;
        }
    }
}