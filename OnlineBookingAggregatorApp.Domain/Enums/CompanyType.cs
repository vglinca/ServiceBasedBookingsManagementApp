using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum CompanyType
    {
        JuridicalPerson,
        PhysicalPerson
    }
    
    public class CompanyTypeEntity : EnumEntity<CompanyType>
    {
        public CompanyTypeEntity()
        {
        }
        
        internal CompanyTypeEntity(CompanyType id, string name) : base(id, name)
        {
        }
    }

    public class CompanyTypeEntityFactory : EnumEntityFactory<CompanyType, CompanyTypeEntity>
    {
        public static CompanyTypeEntityFactory Instance { get; } = new CompanyTypeEntityFactory();

        public CompanyTypeEntityFactory()
        {
            Register(
                new CompanyTypeEntity(CompanyType.JuridicalPerson, "Juridical Person"),
                new CompanyTypeEntity(CompanyType.PhysicalPerson, "Physical Person")
            );
        }
    }
}