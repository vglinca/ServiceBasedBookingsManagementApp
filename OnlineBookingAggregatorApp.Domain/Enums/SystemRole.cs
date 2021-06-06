using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum SystemRole
    {
        CompanyAdmin = 1,
        CompanyAdminDeputy,
        Specialist
    }

    public class SystemRoleEntity : EnumEntity<SystemRole>
    {
        public SystemRoleEntity()
        {
        }

        public SystemRoleEntity(SystemRole id, string name) : base(id, name)
        {
        }
    }

    public class SystemRoleEntityFactory : EnumEntityFactory<SystemRole, SystemRoleEntity>
    {
        public static SystemRoleEntityFactory Instance { get; } = new SystemRoleEntityFactory();

        public SystemRoleEntityFactory()
        {
            Register(
                new SystemRoleEntity(SystemRole.CompanyAdmin, nameof(SystemRole.CompanyAdmin)),
                new SystemRoleEntity(SystemRole.CompanyAdminDeputy, nameof(SystemRole.CompanyAdminDeputy)),
                new SystemRoleEntity(SystemRole.Specialist, nameof(SystemRole.Specialist)));
        }
    }
}