using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Services;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Services;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class ServicesController : BaseController
    {
        [HttpGet("{companyId:long}/services-paged")]
        [PolicyAuthorize(Policy.ViewServices)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<PagedResult<ServiceDto>>> GetPagedGetByCompanyId([FromRoute] long companyId,
            [FromQuery] PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetPagedServicesByCompanyIdQuery, (long, PagedRequest), 
                PagedResult<ServiceDto>>((companyId, pagedRequest), cancellationToken);
        }

        [HttpGet("{companyId:long}/for-select")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<ServiceForSelectDto>>> ForSelect([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetServicesForSelectQuery, long, IList<ServiceForSelectDto>>(companyId, cancellationToken);
        }
        
        [HttpGet("for-select/{specialistId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<ServiceForSelectDto>>> GetForSelectBySpecialist([FromRoute] long specialistId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetEmployeeServicesForSelectQuery, long, IList<ServiceForSelectDto>>(specialistId, cancellationToken);
        }

        [HttpGet("{serviceId:long}")]
        [PolicyAuthorize(Policy.ViewServices)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<ServiceDto>> GetById([FromRoute] long serviceId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetServiceByIdQuery, long, ServiceDto>(serviceId, cancellationToken);
        }

        [HttpGet("name-is-unique")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<bool>> ServiceNameUnique([FromQuery] string name, [FromQuery] long? id, CancellationToken cancellationToken)
        {
            return ExecuteQuery<ServiceNameUniqueQuery, (string, long?), bool>((name, id), cancellationToken);
        }

        [HttpGet("{serviceId:long}/can-delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<bool>> CanDelete([FromRoute] long serviceId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<CanDeleteServiceQuery, long, bool>(serviceId, cancellationToken);
        }

        [HttpPost("{companyId:long}")]
        [PolicyAuthorize(Policy.AddServices)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> Create([FromRoute] long companyId, [FromBody] ServiceCreateDto input)
        {
            return ExecuteCommandReturningEntityId<CreateServiceCommand, (long, ServiceCreateDto), Service>((companyId, input));
        }

        [HttpPut("{serviceId:long}")]
        [PolicyAuthorize(Policy.EditServices)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> Update([FromRoute] long serviceId, [FromBody] ServiceUpdateDto input)
        {
            return ExecuteCommand<UpdateServiceCommand, (long, ServiceUpdateDto)>((serviceId, input));
        }

        [HttpDelete("{serviceId:long}")]
        [PolicyAuthorize(Policy.DeleteServices)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> Delete([FromRoute] long serviceId)
        {
            return ExecuteCommand<DeleteServiceCommand, long>(serviceId);
        }
    }
}