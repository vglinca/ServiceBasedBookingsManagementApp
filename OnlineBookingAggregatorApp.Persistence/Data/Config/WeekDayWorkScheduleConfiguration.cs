using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class WeekDayWorkScheduleConfiguration : BaseEntityTypeConfiguration<WeekDayWorkSchedule>
    {
        public override void Configure(EntityTypeBuilder<WeekDayWorkSchedule> builder)
        {
            base.Configure(builder);
            
            builder.EnumProperty(x => x.DayOfWeek);
            builder.HasOne(x => x.WorkSchedule)
                .WithMany()
                .HasForeignKey(x => x.WorkScheduleId)
                .IsRequired();
        }
    }
}