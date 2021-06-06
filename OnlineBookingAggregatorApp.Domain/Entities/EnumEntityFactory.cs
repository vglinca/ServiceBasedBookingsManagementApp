using System;
using System.Collections.Generic;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public abstract class EnumEntityFactory<TEnum, TEntity> 
        where TEnum : struct, Enum
        where TEntity : EnumEntity<TEnum>
    {
        readonly Dictionary<TEnum, TEntity> _entities = new Dictionary<TEnum, TEntity>();
        public IEnumerable<TEntity> Entities => _entities.Values;

        public TEntity Get(TEnum key)
        {
            if (_entities.TryGetValue(key, out var entity))
            {
                return entity;
            }

            throw new Exception($"No {typeof(TEntity).Name} registered for {typeof(TEnum).Name}.{key.ToString()}.");
        }
        
        public TEntity GetNullable(TEnum? key)
        {
            return key == null ? null : Get(key.Value);
        }
        
        protected void Register(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                var key = (TEnum) Enum.ToObject(typeof(TEnum), entity.Id);

                if (!_entities.TryAdd(key, entity))
                {
                    throw new Exception($"{typeof(TEntity).Name} already registered for {typeof(TEnum).Name}.{key.ToString()}.");
                }
            }
        }
    }
}