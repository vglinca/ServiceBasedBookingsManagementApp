using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Employees;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public class EmployeesController : BaseController
    {
        [HttpGet("{companyId:long}/employees-paged")]
        [PolicyAuthorize(Policy.ViewEmployees)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<PagedResult<EmployeeDto>>> GetPaged([FromRoute] long companyId, 
            [FromQuery] PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetEmployeesPagedQuery, (long, PagedRequest), PagedResult<EmployeeDto>>((companyId, pagedRequest), cancellationToken);
        }

        [HttpGet("{companyId:long}/for-select-list")]
        [PolicyAuthorize(Policy.ViewEmployees)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<EmployeeForSelectDto>>> GetForSelect([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetEmployeesForSelectQuery, long, IList<EmployeeForSelectDto>>(companyId, cancellationToken);
        }

        [HttpGet("{employeeId:long}")]
        [PolicyAuthorize(Policy.ViewEmployees)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<EmployeeDto>> GetById([FromRoute] long employeeId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetEmployeeByIdQuery, long, EmployeeDto>(employeeId, cancellationToken);
        }

        [HttpPost("{companyId:long}/add-employee")]
        [PolicyAuthorize(Policy.AddEmployees)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> Add([FromRoute] long companyId, [FromBody] EmployeeCreateUpdateDto input)
        {
            return ExecuteCommand<AddEmployeeCommand, (long, EmployeeCreateUpdateDto), long>((companyId, input));
        }

        [HttpPut("{employeeId:long}")]
        [PolicyAuthorize(Policy.EditEmployees)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<ActionResult> Update([FromRoute] long employeeId, [FromBody] EmployeeCreateUpdateDto input)
        {
            return ExecuteCommand<UpdateEmployeeCommand, (long, EmployeeCreateUpdateDto)>((employeeId, input));
        }

        [HttpDelete("{employeeId:long}")]
        [PolicyAuthorize(Policy.DeleteEmployees)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<ActionResult> Delete([FromRoute] long employeeId)
        {
            return ExecuteCommand<DeleteEmployeeCommand, long>(employeeId);
        }
    }
}