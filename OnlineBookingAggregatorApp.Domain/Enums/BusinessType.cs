using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum BusinessType
    {
        Beauty = 1,
        Healthcare,
        Sport,
        Education,
        Entertainment,
        HouseholdServices,
        Auto,
        Retail,
        Other
    }

    public class BusinessTypeEntity : EnumEntity<BusinessType>
    {
        public BusinessTypeEntity()
        {
        }

        internal BusinessTypeEntity(BusinessType id, string name) : base(id, name)
        {
        }
    }

    public class BusinessTypeEntityFactory : EnumEntityFactory<BusinessType, BusinessTypeEntity>
    {
        public static BusinessTypeEntityFactory Instance { get; } = new BusinessTypeEntityFactory();

        public BusinessTypeEntityFactory()
        {
            Register(
                new BusinessTypeEntity(BusinessType.Beauty, "Beauty"),
                new BusinessTypeEntity(BusinessType.Healthcare, "Healthcare"),
                new BusinessTypeEntity(BusinessType.Sport, "Sport"),
                new BusinessTypeEntity(BusinessType.Education, "Education"),
                new BusinessTypeEntity(BusinessType.Entertainment, "Entertainment"),
                new BusinessTypeEntity(BusinessType.HouseholdServices, "HouseholdServices"),
                new BusinessTypeEntity(BusinessType.Auto, "Auto"),
                new BusinessTypeEntity(BusinessType.Retail, "Retail"),
                new BusinessTypeEntity(BusinessType.Other, "Other"));
        }
    }
}