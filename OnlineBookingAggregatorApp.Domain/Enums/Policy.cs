using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Utils;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum Policy
    {
        [DefaultRole(SystemRole.CompanyAdmin)]
        ViewPermissions = 1,
        
        [DefaultRole(SystemRole.CompanyAdmin)]
        EditPermissions,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        ViewCompanyDetails,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        EditCompanyDetails,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        ViewAllBookings,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        EditUnrelatedBookings,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        DeleteUnrelatedBookings,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        CreateUnrelatedBookings,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        ViewClients,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        AddClients,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        EditClients,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        DeleteClients,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.CompanyAdminDeputy)]
        ViewEmployees,

        [DefaultRole(SystemRole.CompanyAdmin)]
        AddEmployees,

        [DefaultRole(SystemRole.CompanyAdmin)]
        EditEmployees,

        [DefaultRole(SystemRole.CompanyAdmin)]
        DeleteEmployees,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        ViewWorkSchedule,

        [DefaultRole(SystemRole.CompanyAdmin)]
        EditWorkSchedule,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        ViewCategories,

        [DefaultRole(SystemRole.CompanyAdmin)]
        AddCategories,

        [DefaultRole(SystemRole.CompanyAdmin)]
        EditCategories,

        [DefaultRole(SystemRole.CompanyAdmin)]
        DeleteCategories,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        ViewPositions,

        [DefaultRole(SystemRole.CompanyAdmin)]
        AddPositions,

        [DefaultRole(SystemRole.CompanyAdmin)]
        EditPositions,

        [DefaultRole(SystemRole.CompanyAdmin)]
        DeletePositions,

        [DefaultRole(SystemRole.CompanyAdmin, SystemRole.Specialist, SystemRole.CompanyAdminDeputy)]
        ViewServices,

        [DefaultRole(SystemRole.CompanyAdmin)]
        AddServices,

        [DefaultRole(SystemRole.CompanyAdmin)]
        EditServices,

        [DefaultRole(SystemRole.CompanyAdmin)]
        DeleteServices
    }
    
    public class PolicyEntity : EnumEntity<Policy>
    {
        public PolicyEntity() { }
        public PolicyEntity(Policy id, string name) : base(id, name) { }
    }

    public class PolicyEntityFactory : EnumEntityFactory<Policy, PolicyEntity>
    {
        public static PolicyEntityFactory Instance { get; } = new PolicyEntityFactory();

        public PolicyEntityFactory()
        {
            Register(
                new PolicyEntity(Policy.ViewPermissions, nameof(Policy.ViewPermissions)),
                new PolicyEntity(Policy.EditPermissions, nameof(Policy.EditPermissions)),
                new PolicyEntity(Policy.ViewCompanyDetails, nameof(Policy.ViewCompanyDetails)),
                new PolicyEntity(Policy.EditCompanyDetails, nameof(Policy.EditCompanyDetails)),
                new PolicyEntity(Policy.ViewAllBookings, nameof(Policy.ViewAllBookings)),
                new PolicyEntity(Policy.EditUnrelatedBookings, nameof(Policy.EditUnrelatedBookings)),
                new PolicyEntity(Policy.DeleteUnrelatedBookings, nameof(Policy.DeleteUnrelatedBookings)),
                new PolicyEntity(Policy.CreateUnrelatedBookings, nameof(Policy.CreateUnrelatedBookings)),
                new PolicyEntity(Policy.ViewClients, nameof(Policy.ViewClients)),
                new PolicyEntity(Policy.AddClients, nameof(Policy.AddClients)),
                new PolicyEntity(Policy.EditClients, nameof(Policy.EditClients)),
                new PolicyEntity(Policy.DeleteClients, nameof(Policy.DeleteClients)),
                new PolicyEntity(Policy.ViewEmployees, nameof(Policy.ViewEmployees)),
                new PolicyEntity(Policy.AddEmployees, nameof(Policy.AddEmployees)),
                new PolicyEntity(Policy.EditEmployees, nameof(Policy.EditEmployees)),
                new PolicyEntity(Policy.DeleteEmployees, nameof(Policy.DeleteEmployees)),
                new PolicyEntity(Policy.ViewWorkSchedule, nameof(Policy.ViewWorkSchedule)),
                new PolicyEntity(Policy.EditWorkSchedule, nameof(Policy.EditWorkSchedule)),
                new PolicyEntity(Policy.ViewCategories, nameof(Policy.ViewCategories)),
                new PolicyEntity(Policy.AddCategories, nameof(Policy.AddCategories)),
                new PolicyEntity(Policy.EditCategories, nameof(Policy.EditCategories)),
                new PolicyEntity(Policy.DeleteCategories, nameof(Policy.DeleteCategories)),
                new PolicyEntity(Policy.ViewPositions, nameof(Policy.ViewPositions)),
                new PolicyEntity(Policy.AddPositions, nameof(Policy.AddPositions)),
                new PolicyEntity(Policy.EditPositions, nameof(Policy.EditPositions)),
                new PolicyEntity(Policy.DeletePositions, nameof(Policy.DeletePositions)),
                new PolicyEntity(Policy.ViewServices, nameof(Policy.ViewServices)),
                new PolicyEntity(Policy.AddServices, nameof(Policy.AddServices)),
                new PolicyEntity(Policy.EditServices, nameof(Policy.EditServices)),
                new PolicyEntity(Policy.DeleteServices, nameof(Policy.DeleteServices))
                );
        }
    }
}