using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class PolicyRoleConfiguration : BaseEntityTypeConfiguration<PolicyRole>
    {
        public override void Configure(EntityTypeBuilder<PolicyRole> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new {x.Policy, x.Role}).IsUnique();
            builder.Property(x => x.IsSetByDefault)
                .HasConversion<bool>()
                .IsRequired();
        }
    }
}