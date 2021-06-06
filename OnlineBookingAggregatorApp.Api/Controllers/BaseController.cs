using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookingAggregatorApp.Core;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure;

// ReSharper disable All

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class BaseController : ControllerBase
    {
        protected IUnitOfWork UnitOfWork => HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
        public BaseController() {}
        
        protected async Task<ActionResult<TOutput>> ExecuteQuery<TQuery, TOutput>(CancellationToken cancellationToken) 
            where TQuery : Query<TOutput>  
        {
            var query = HttpContext.RequestServices.GetRequiredService<TQuery>();
            return await query.ExecuteAsync(cancellationToken);
        }

        protected async Task<ActionResult<TOutput>> ExecuteQuery<TQuery, TInput, TOutput>(TInput input,
            CancellationToken cancellationToken)
            where TQuery : Query<TInput, TOutput>
        {
            var query = HttpContext.RequestServices.GetRequiredService<TQuery>();
            return await query.ExecuteAsync(input, cancellationToken);
        }
        
        protected async Task<ActionResult<TOutput>> ExecuteQueryReturningSimpleValue<TQuery, TInput, TOutput>(TInput input,
            CancellationToken cancellationToken)
            where TQuery : Query<TInput, TOutput>
        {
            var query = HttpContext.RequestServices.GetRequiredService<TQuery>();
            return await query.ExecuteAsync(input, cancellationToken);
        }

        protected async Task<ActionResult> ExecuteCommand<TCommand>() where TCommand : Command
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            await command.ExecuteAsync();
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> ExecuteCommand<TCommand, TInput>(TInput input)
            where TCommand : Command<TInput>
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            await command.ExecuteAsync(input);
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult<TOutput>> ExecuteCommand<TCommand, TInput, TOutput>(TInput input)
            where TCommand : Command<TInput, TOutput>
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            var output = await command.ExecuteAsync(input);
            await UnitOfWork.SaveChangesAsync();
            return Ok(output);
        }

        protected async Task<ActionResult<long>> ExecuteCommandReturningEntityId<TCommand, TInput, TOutput>(TInput input)
            where TCommand : Command<TInput, TOutput> where TOutput : Entity
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            var output = await command.ExecuteAsync(input);
            await UnitOfWork.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, output.Id);
        }
    }
}