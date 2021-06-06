using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class BookingConfiguration : BaseEntityTypeConfiguration<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);
            builder.EnumProperty(x => x.Colour);
            builder.EnumProperty(x => x.State);
            builder.Property(x => x.State).HasDefaultValue(BookingState.WaitingForClient);
            builder.Property(x => x.Comments).HasMaxLength(1000);
            builder.HasOne(x => x.Service)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.ServiceId)
                .IsRequired();
            builder.HasOne(x => x.Specialist)
                .WithMany(y => y.Bookings)
                .HasForeignKey(x => x.SpecialistId)
                .IsRequired();
        }
    }
}