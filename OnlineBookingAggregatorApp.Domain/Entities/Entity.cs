using System;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; private set; }
        public DateTimeOffset SystemCreatedDate { get; private set; }
        public long? CreatedById { get; set; }
        public DateTimeOffset UpdatedDate { get; private set; }
        public long? UpdatedById { get; set; }

        protected Entity()
        {
            SystemCreatedDate = DateTimeOffset.UtcNow;
            UpdatedDate = DateTimeOffset.Now;
        }

        protected Entity(long id) : this()
        {
            Id = id;
        }

        public void SetCreatedBy(long? createdById)
        {
            CreatedById = createdById;
        }

        public void SetUpdatedBy(long? updatedById)
        {
            UpdatedById = updatedById;
            UpdatedDate = DateTimeOffset.Now;
        }

        public void SetId(long id)
        {
            Id = id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}