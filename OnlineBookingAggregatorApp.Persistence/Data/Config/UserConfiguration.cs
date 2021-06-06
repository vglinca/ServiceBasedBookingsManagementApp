using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Specialization).HasMaxLength(100);
            builder.Property(x => x.Information).HasMaxLength(1000);
            
            builder.EnumProperty(x => x.Gender);
            builder.EnumProperty(x => x.EmployeeStatus);
            builder.EnumProperty(x => x.SystemRole);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.PositionId);
            
            builder.HasMany(x => x.WorkSchedules)
                .WithOne(y => y.Employee)
                .HasForeignKey(y => y.EmployeeId)
                .IsRequired();

            builder.Property(x => x.EmployeeStatus)
                .HasDefaultValue(EmployeeStatus.Active);
        }
    }
}