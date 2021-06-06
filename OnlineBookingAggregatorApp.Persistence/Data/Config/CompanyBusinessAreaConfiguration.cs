using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class CompanyBusinessAreaConfiguration : BaseEntityTypeConfiguration<CompanyBusinessArea>
    {
        public override void Configure(EntityTypeBuilder<CompanyBusinessArea> builder)
        {
            base.Configure(builder);
            builder.EnumProperty(x => x.BusinessArea);
        }
    }
}