using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<TSource> FirstByIdOrDefaultAsync<TSource>(this IQueryable<TSource> src, 
            long id, CancellationToken cancellationToken = default) 
            where TSource : Entity
        {
            return await src.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? 
                   throw EntityNotFoundException.OfType<TSource>();
        }
        
        public static async Task<TSource> FirstByIdAsync<TSource>(this IQueryable<TSource> src, long id, CancellationToken cancellationToken = default) 
            where TSource : Entity
        {
            return await src.FirstAsync(x => x.Id == id, cancellationToken) ?? 
                   throw EntityNotFoundException.OfType<TSource>();
        }
        
        public static async Task<TSource> SingleByIdAsync<TSource>(this IQueryable<TSource> src, long id, CancellationToken cancellationToken = default ) 
            where TSource : Entity
        {
            return await src.SingleAsync(x => x.Id.Equals(id), cancellationToken) ?? 
                   throw EntityNotFoundException.OfType<TSource>();
        }
        
        public static async Task<TSource> SingleByIdOrDefaultAsync<TSource>(this IQueryable<TSource> src, long id, CancellationToken cancellationToken = default ) 
            where TSource : Entity
        {
            return await src.SingleOrDefaultAsync(x => x.Id == id, cancellationToken) ?? 
                   throw EntityNotFoundException.OfType<TSource>();
        }

        public static async Task AssertEntityExistsAsync<TSource>(this IQueryable<TSource> src, long id) 
            where TSource : Entity
        {
            if (! await src.AnyAsync(x => x.Id.Equals(id)))
            {
                throw EntityNotFoundException.OfType<TSource>();
            }
        }
        
        public static async Task AssertUserExistsAsync<TSource>(this IQueryable<TSource> src, long id, CancellationToken cancellationToken = default) 
            where TSource : User
        {
            if (! await src.AnyAsync(x => x.Id.Equals(id), cancellationToken))
            {
                throw EntityNotFoundException.OfType<TSource>();
            }
        }
        
        public static async Task<TSource> FirstUserByIdAsync<TSource>(this IQueryable<TSource> src, long id, CancellationToken cancellationToken = default) where TSource : User
        {
            return await src.FirstAsync(x => x.Id == id, cancellationToken) ?? 
                   throw EntityNotFoundException.OfType<TSource>();
        }
        
        public static async Task<TSource> SingleUserByIdAsync<TSource>(this IQueryable<TSource> src, long id) where TSource : User
        {
            return await src.SingleAsync(x => x.Id == id) ?? throw EntityNotFoundException.OfType<TSource>();
        }
    }
}