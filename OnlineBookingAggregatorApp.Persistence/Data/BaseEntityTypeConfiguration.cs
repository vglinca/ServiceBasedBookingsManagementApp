using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data
{
    public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).HasColumnName($"{typeof(TEntity).Name}Id");
            builder.HasKey(e => e.Id);
            builder.HasOne<User>().WithMany().HasForeignKey(e => e.CreatedById);
            builder.HasOne<User>().WithMany().HasForeignKey(e => e.UpdatedById);
        }
    }
}