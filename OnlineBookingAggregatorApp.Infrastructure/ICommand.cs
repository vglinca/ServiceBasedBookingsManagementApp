using System;
using System.Threading.Tasks;

namespace OnlineBookingAggregatorApp.Infrastructure
{
    [Obsolete("Use Command instead")]
    public interface ICommand { }
    [Obsolete("Use Command instead")]
    public interface ICommand<TOutput>{ }
    
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
    
    public interface ICommandHandler<TCommand, TOutput> where TCommand : ICommand<TOutput>
    {
        Task<TOutput> ExecuteAsync(TCommand command);
    }
}