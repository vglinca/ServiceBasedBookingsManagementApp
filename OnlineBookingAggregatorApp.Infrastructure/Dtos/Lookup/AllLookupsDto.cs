using System.Collections.Generic;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class AllLookupsDto
    {
        public IList<BusinessTypeDto> BusinessTypes { get; set; }
        public IList<BusinessAreaDto> BusinessAreas { get; set; }
        public IList<CompanyTypeDto> CompanyTypes { get; set; }
        public IList<GenderDto> Genders { get; set; }
        public IList<EmployeesQuantityDto> EmployeesQuantities { get; set; }
        public IList<EmployeeStatusDto> EmployeeStatuses { get; set; }
        public IList<ServiceTargetGroupDto> ServiceTargetGroups { get; set; }
        public IList<PolicyLookupDto> Policies { get; set; }
        public IList<RoleDto> Roles { get; set; }
        public IList<ClientCategoryDto> ClientCategories { get; set; }
        public IList<ColourDto> Colours { get; set; }
        public IList<BookingStateDto> BookingStates { get; set; }
    }
}