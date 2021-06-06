using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Domain.ValueObjects;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Persistence.Data.Config
{
    public class CompanyConfiguration : BaseEntityTypeConfiguration<Company>
    {
        private static readonly ValueConverter AddressConverter = new ValueConverter<Address, string>(
            a => JsonConvert.SerializeObject(a),
            a => JsonConvert.DeserializeObject<Address>(a));
        private static readonly ValueConverter EmailAddressConverter = new ValueConverter<EmailAddress, string>(
            x => x.Value,
            x => EmailAddress.From(x));
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);
            
            builder.EnumProperty(x => x.BusinessType);
            builder.EnumProperty(x => x.CompanyType);
            builder.EnumProperty(x => x.EmployeesSize);
            builder.Property(e => e.Address).HasJsonConversion().IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Email).HasConversion(EmailAddressConverter).IsRequired();
            builder.HasMany<Category>()
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();
            builder.HasMany(x => x.CompanyBusinessAreas)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();
            builder.HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Clients)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();
            builder.Property(x => x.EmployeesSize).HasDefaultValue(EmployeesSize.One);
        }
    }
}