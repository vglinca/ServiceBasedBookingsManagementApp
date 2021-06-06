using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data
{
    public abstract class EnumEntityTypeConfiguration<TEnum, TEntity> : IEntityTypeConfiguration<TEntity>
        where TEnum : struct, Enum
        where TEntity : EnumEntity<TEnum>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion<long>()
                .HasColumnName($"{typeof(TEnum).Name}Id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();
        }
    }
}