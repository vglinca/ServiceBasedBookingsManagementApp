using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Clients;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Clients;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class ClientsController : BaseController
    {
        [HttpGet("{companyId:long}/paged")]
        [PolicyAuthorize(Policy.ViewClients)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<PagedResult<ClientDto>>> GetPaged([FromRoute] long companyId, 
            [FromQuery] PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetClientsPagedQuery, (long, PagedRequest), PagedResult<ClientDto>>((companyId, pagedRequest), cancellationToken);
        }

        [HttpGet("{companyId:long}/for-select")]
        [PolicyAuthorize(Policy.ViewClients)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<ClientForSelectDto>>> ForSelect([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetClientsForSelectQuery, long, IList<ClientForSelectDto>>(companyId, cancellationToken);
        }

        [HttpGet("{clientId:long}")]
        [PolicyAuthorize(Policy.ViewClients)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<ClientDto>> GetById([FromRoute] long clientId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetClientByIdQuery, long, ClientDto>(clientId, cancellationToken);
        }

        [HttpPost("{companyId:long}")]
        [PolicyAuthorize(Policy.AddClients)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> Create([FromRoute] long companyId, [FromBody] ClientCreateUpdateDto input)
        {
            return ExecuteCommandReturningEntityId<AddClientCommand, (long, ClientCreateUpdateDto), Client>((companyId, input));
        }

        [HttpPut("{clientId:long}")]
        [PolicyAuthorize(Policy.EditClients)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> Update([FromRoute] long clientId, [FromBody] ClientCreateUpdateDto input)
        {
            return ExecuteCommand<UpdateClientCommand, (long, ClientCreateUpdateDto)>((clientId, input));
        }
        
        [HttpPut("{clientId:long}/set-category")]
        [PolicyAuthorize(Policy.EditClients)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> UpdateClientCategory([FromRoute] long clientId, [FromBody] ClientCategoryUpdateDto input)
        {
            return ExecuteCommand<ChangeClientCategoryCommand, (long,ClientCategoryUpdateDto)>((clientId, input));
        }

        [HttpDelete("{clientId:long}")]
        [PolicyAuthorize(Policy.DeleteClients)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> Delete([FromRoute] long clientId)
        {
            return ExecuteCommand<DeleteClientCommand, long>(clientId);
        }
    }
}