using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineBookingAggregatorApp.Core;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Persistence.Data;
using static System.Int64;

namespace OnlineBookingAggregatorApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly HttpContext _httpContext;

        public UnitOfWork(AppDbContext dbContext, IHttpContextAccessor accessor)
        {
            _dbContext = dbContext;
            _httpContext = accessor.HttpContext;
        }

        public void AssertEntityAdded<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = _dbContext.ChangeTracker.Entries<TEntity>()
                .SingleOrDefault(e => e.Entity == entity);

            if (entry == null || !entry.IsKeySet)
            {
                throw new InvalidOperationException(
                    $"Can not return {nameof(Entity.Id)} of {typeof(TEntity).Name} that has not been added to the database.");
            }
        }

        public async Task SaveChangesAsync()
        {
            TryParse(
                _httpContext.User.Claims.FirstOrDefault(x => x.Type == AppConstants.Parameters.UserId)?.Value, 
                out var userId);
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            UpdateEntities(userId);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        private void UpdateEntities(long? userId)
        {
            var entityEntries = _dbContext.ChangeTracker.Entries<Entity>();

            foreach (var entry in entityEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        SetCreatedBy(entry, userId);
                        break;
                    case EntityState.Modified:
                        SetUpdatedBy(entry, userId);
                        break;
                }
            }
        }
        
        private static void SetCreatedBy(EntityEntry<Entity> entry, long? userId)
        {
            if (userId == null)
            {
                return;
            }
            entry.Entity.SetCreatedBy(userId);
            entry.Entity.SetUpdatedBy(userId);
        }

        private static void SetUpdatedBy(EntityEntry<Entity> entry, long? userId)
        {
            if (userId == null)
            {
                return;
            }
            
            entry.Entity.SetUpdatedBy(userId);
        }
    }
}