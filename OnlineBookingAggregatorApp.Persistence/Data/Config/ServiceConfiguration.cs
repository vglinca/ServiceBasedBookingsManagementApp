using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class ServiceConfiguration : BaseEntityTypeConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(1000);
        }
    }
}