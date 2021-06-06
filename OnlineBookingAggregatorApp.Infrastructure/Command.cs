using System.Threading.Tasks;

namespace OnlineBookingAggregatorApp.Infrastructure
{
    public abstract class Command
    {
        public abstract Task ExecuteAsync();
    }
    public abstract class Command<TInput>
    {
        public abstract Task ExecuteAsync(TInput input);
    }

    public abstract class Command<TInput, TOutput>
    {
        public abstract Task<TOutput> ExecuteAsync(TInput input);
    }
}