using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Roles
{
    public class UpdateRolePoliciesCommand : Command<UpdateRolePoliciesDto>
    {
        private readonly AppDbContext _appDbContext;

        public UpdateRolePoliciesCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public override async Task ExecuteAsync(UpdateRolePoliciesDto input)
        {
            var role = (SystemRole) input.RoleId;
            var rolePolicies = await _appDbContext.PolicyRoles
                .Where(x => x.Role == role)
                .ToListAsync();

            var rolePoliciesToDelete = rolePolicies
                .Where(x => !input.Policies.Contains(x.Policy))
                .ToList();

            var rolePoliciesToAdd = input.Policies
                .Where(x => !rolePolicies.Select(y => y.Policy).Contains(x))
                .Select(x => new PolicyRole(x, role, false))
                .ToList();

            _appDbContext.PolicyRoles.RemoveRange(rolePoliciesToDelete);
            await _appDbContext.PolicyRoles.AddRangeAsync(rolePoliciesToAdd);
        }
    }
}