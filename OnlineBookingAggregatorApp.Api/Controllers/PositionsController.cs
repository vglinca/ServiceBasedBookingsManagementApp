using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Positions;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Positions;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class PositionsController : BaseController
    {

        [HttpGet("{companyId:long}/paged")]
        [PolicyAuthorize(Policy.ViewPositions)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<PagedResult<PositionDto>>> GetCompanyPositionsPaged([FromRoute] long companyId, 
            [FromQuery] PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCompanyPositionsPagedQuery, (long, PagedRequest), PagedResult<PositionDto>>((companyId, pagedRequest), cancellationToken);
        }

        [HttpGet("{companyId:long}/for-select")]
        [PolicyAuthorize(Policy.ViewPositions)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<PositionDto>>> GetPositionsForSelect([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCompanyPositionsForSelectQuery, long, IList<PositionDto>>(companyId, cancellationToken);
        }

        [HttpGet("{positionId:long}")]
        [PolicyAuthorize(Policy.ViewPositions)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<PositionDto>> GetPositionById([FromRoute] long positionId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetPositionByIdQuery, long, PositionDto>(positionId, cancellationToken);
        }

        [HttpPost("{companyId:long}")]
        [PolicyAuthorize(Policy.AddPositions)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> AddPosition([FromRoute] long companyId, [FromBody] PositionCreateUpdateDto input)
        {
            return ExecuteCommandReturningEntityId<AddPositionCommand, (long, PositionCreateUpdateDto), Position>((companyId, input));
        }

        [HttpPut("{positionId:long}")]
        [PolicyAuthorize(Policy.EditPositions)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<ActionResult> UpdatePosition([FromRoute] long positionId, [FromBody] PositionCreateUpdateDto input)
        {
            return ExecuteCommand<UpdatePositionCommand, (long, PositionCreateUpdateDto)>((positionId, input));
        }

        [HttpDelete("{positionId:long}")]
        [PolicyAuthorize(Policy.DeletePositions)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<ActionResult> RemovePosition([FromRoute] long positionId)
        {
            return ExecuteCommand<DeletePositionCommand, long>(positionId);
        }
    }
}