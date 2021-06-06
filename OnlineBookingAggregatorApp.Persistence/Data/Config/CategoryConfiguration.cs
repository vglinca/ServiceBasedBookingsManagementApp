using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class CategoryConfiguration : BaseEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            
            builder.EnumProperty(x => x.BusinessArea);
            builder.EnumProperty(x => x.ServiceTargetGroup);
            builder.Property(x => x.ServiceTargetGroup)
                .HasDefaultValue(ServiceTargetGroup.General);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany<Service>()
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
        }
    }
}