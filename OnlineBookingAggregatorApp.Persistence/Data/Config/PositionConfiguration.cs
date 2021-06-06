using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class PositionConfiguration : BaseEntityTypeConfiguration<Position>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}