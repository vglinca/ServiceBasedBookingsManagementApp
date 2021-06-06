using System.Threading.Tasks;

namespace OnlineBookingAggregatorApp.Core
{
    public interface IUnitOfWork
    {
        public void AssertEntityAdded<TEntity>(TEntity entity) where TEntity : class;
        public Task SaveChangesAsync();
    }
}