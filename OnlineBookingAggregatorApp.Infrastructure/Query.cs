using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookingAggregatorApp.Infrastructure
{
    public abstract class Query<TOutput>
    {
        public abstract Task<TOutput> ExecuteAsync(CancellationToken cancellationToken = default);
    }

    public abstract class Query<TInput, TOutput>
    {
        public abstract Task<TOutput> ExecuteAsync(TInput input, CancellationToken cancellationToken = default);
    }
}