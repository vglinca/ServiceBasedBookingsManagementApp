using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Infrastructure;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Users;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class UsersController : BaseController
    {
        [HttpGet("check-unique-email")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<bool>> CheckUserEmailUnique([FromQuery] string email, CancellationToken cancellationToken)
        {
            return ExecuteQueryReturningSimpleValue<CheckUserEmailUniqueQuery, string, bool>(email, cancellationToken);
        }

        [HttpGet("check-user-has-created-company/{userId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<bool>> CheckUserHasCreatedCompany([FromRoute] long userId, CancellationToken cancellationToken)
        {
            return ExecuteQueryReturningSimpleValue<CheckUserHasCreatedCompanyQuery, long, bool>(userId, cancellationToken);
        }

        [HttpGet("{userId:long}/brief-info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<EmployeeForSelectDto>> GetUserBriefInfo([FromRoute] long userId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetUserBriefInfoQuery, long, EmployeeForSelectDto>(userId, cancellationToken);
        }
    }
}