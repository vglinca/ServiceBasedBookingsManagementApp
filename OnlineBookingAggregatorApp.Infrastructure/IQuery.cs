using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookingAggregatorApp.Infrastructure
{
    [Obsolete("Use Query instead")]
    public interface IQuery<TResult>
    {
    }
    
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query, CancellationToken cancellationToken);
    }
}