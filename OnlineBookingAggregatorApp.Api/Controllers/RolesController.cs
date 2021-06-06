using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Roles;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Roles;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class RolesController : BaseController
    {
        [HttpGet("role-policies")]
        [PolicyAuthorize(Policy.ViewPermissions)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<RolePoliciesDto>>> GetRolePolicies(CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetRolesWithPoliciesQuery, IList<RolePoliciesDto>>(cancellationToken);
        }

        [HttpPut]
        [PolicyAuthorize(Policy.EditPermissions)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult> UpdateRolePolicies([FromBody] UpdateRolePoliciesDto input)
        {
            return ExecuteCommand<UpdateRolePoliciesCommand, UpdateRolePoliciesDto>(input);
        }
    }
}