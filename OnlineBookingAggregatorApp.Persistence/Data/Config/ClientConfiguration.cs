using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class ClientConfiguration : BaseEntityTypeConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);
            builder.EnumProperty(x => x.ClientCategory);
            builder.EnumProperty(x => x.Gender);
            builder.Property(x => x.ClientCategory).HasDefaultValue(ClientCategory.Loyal);

            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasMaxLength(40);
            builder.Property(x => x.AdditionalPhoneNumber).HasMaxLength(40);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Comments).HasMaxLength(1000);
            builder.HasMany<Booking>()
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .IsRequired();
        }
    }
}