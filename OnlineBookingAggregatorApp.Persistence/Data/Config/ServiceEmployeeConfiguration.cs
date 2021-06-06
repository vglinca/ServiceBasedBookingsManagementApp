using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class ServiceEmployeeConfiguration : BaseEntityTypeConfiguration<ServiceEmployee>
    {
        public override void Configure(EntityTypeBuilder<ServiceEmployee> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceId)
                .IsRequired();

            builder.HasOne(x => x.Employee)
                .WithMany(y => y.ServiceEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .IsRequired();
        }
    }
}