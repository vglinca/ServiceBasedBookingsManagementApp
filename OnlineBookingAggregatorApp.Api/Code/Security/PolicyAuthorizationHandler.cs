using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Api.Security
{
    public class PolicyAuthorizationHandler : AuthorizationHandler<PolicyAssigned>
    {
        private readonly AppDbContext _dbContext;

        public PolicyAuthorizationHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyAssigned requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return;
            }

            var userRole = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            
            var roleId = (SystemRole) Enum.Parse(typeof(SystemRole), userRole, false);
            var policies = await _dbContext.PolicyRoles.AsNoTracking()
                .Where(x => x.Role == roleId)
                .ToListAsync();
            
            var hasPolicy = policies.Any(x => x.Policy.ToString().Equals(requirement.PolicyName));
            
            if (!hasPolicy)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}