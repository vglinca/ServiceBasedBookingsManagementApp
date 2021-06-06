using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure
{
    [Obsolete]
    public interface IMediator
    {
        Task DispatchAsync(ICommand command);
        Task<T> DispatchAsync<T>(ICommand<T> command);
        Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default);
    }
    
    [Obsolete]
    public sealed class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(ICommand command)
        {
            var type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            await handler.ExecuteAsync((dynamic) command);
        }
        
        public async Task<TOutput> DispatchAsync<TOutput>(ICommand<TOutput> command)
        {
            var type = typeof(ICommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(TOutput) };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            TOutput result = await handler.ExecuteAsync((dynamic) command);

            return result;
        }

        public async Task<TOutput> DispatchAsync<TOutput>(IQuery<TOutput> query, CancellationToken cancellationToken = default)
        {
            var type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(TOutput) };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            TOutput result = await handler.ExecuteAsync((dynamic) query, cancellationToken);

            return result;
        }
    }
}