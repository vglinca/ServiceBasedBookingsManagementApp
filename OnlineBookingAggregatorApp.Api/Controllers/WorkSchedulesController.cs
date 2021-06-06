using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.WorkSchedules;
using OnlineBookingAggregatorApp.Infrastructure.Queries.WorkSchedules;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class WorkSchedulesController : BaseController
    {
        [HttpGet("{employeeId:long}")]
        [PolicyAuthorize(Policy.ViewWorkSchedule)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<WorkScheduleDto>>> GetEmployeeWorkSchedules([FromRoute] long employeeId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetEmployeeWorkSchedulesQuery, long, IList<WorkScheduleDto>>(employeeId, cancellationToken);
        }

        [HttpGet("employees-work-hours")]
        [PolicyAuthorize(Policy.ViewWorkSchedule)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<WeekDayWorkHoursDto>>> GetEmployeesWorkHours([FromQuery] long[] employeeIds, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetEmployeesWorkHoursQuery, long[], IList<WeekDayWorkHoursDto>>(employeeIds, cancellationToken);
        }
    }
}