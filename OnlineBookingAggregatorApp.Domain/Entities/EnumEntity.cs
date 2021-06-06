using System;
using OnlineBookingAggregatorApp.Core.Exceptions;
// ReSharper disable MemberCanBePrivate.Global

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public abstract class EnumEntity<TEnum> where TEnum: struct, Enum
    {
        public TEnum Id { get; private set; }
        public string Name { get; private set; }
        public long ParentId { get; private set; }

        public EnumEntity()
        {
        }

        protected EnumEntity(TEnum id, string name, long parentId = 0)
        {
            Id = id;
            Name = name ?? throw new DomainArgumentNullException(nameof(TEnum));
            ParentId = parentId;
        }
    }
}