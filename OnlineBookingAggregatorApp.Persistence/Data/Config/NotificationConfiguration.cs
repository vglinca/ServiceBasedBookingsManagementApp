using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class NotificationConfiguration : BaseEntityTypeConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).HasMaxLength(30);
            builder.Property(x => x.Message).HasMaxLength(1000);
            builder.HasOne<User>()
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.ReceiverId);
        }
    }
}