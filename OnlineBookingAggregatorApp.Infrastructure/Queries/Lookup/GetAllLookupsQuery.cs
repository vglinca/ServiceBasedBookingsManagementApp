using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Clients;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Lookup
{
    public class GetAllLookupsQuery : Query<AllLookupsDto>
    {
        public override Task<AllLookupsDto> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var allLookupsDto = new AllLookupsDto
            {
                BusinessTypes = GetBusinessTypes(),
                BusinessAreas = GetBusinessAreas(),
                CompanyTypes = GetFirstRankClientTypes(),
                Genders = GetGenders(),
                EmployeesQuantities = GetEmployeesQuantities(),
                EmployeeStatuses = GetEmployeeStatuses(),
                ServiceTargetGroups = GetServiceTargetGroups(),
                Policies = GetPolicies(),
                Roles = GetRoles(),
                ClientCategories = GetClientCategories(),
                Colours = GetColours(),
                BookingStates = GetBookingStates()
            };

            return Task.FromResult(allLookupsDto);
        }
        
        private static List<BusinessTypeDto> GetBusinessTypes() =>
            Enum.GetValues(typeof(BusinessType))
                .Cast<BusinessType>()
                .Select(BusinessTypeDto.From)
                .ToList();
        
        private static List<BusinessAreaDto> GetBusinessAreas()
        {
            var values = Enum.GetValues(typeof(BusinessArea))
                .Cast<BusinessArea>()
                .Where(x => x != BusinessArea.SelfEmployedSpecialist)
                .Select(BusinessAreaDto.From)
                .ToList();
            
            var selfEmployedSpecialistTypeEntity = BusinessAreaEntityFactory.Instance.Get(BusinessArea.SelfEmployedSpecialist);
        
            values.AddRange(Enum.GetValues(typeof(BusinessType))
                .Cast<BusinessType>()
                .Where(x => x != BusinessType.Other)
                .Select(enumType => new BusinessAreaDto
                {
                    Id = (long) selfEmployedSpecialistTypeEntity.Id, 
                    Name = selfEmployedSpecialistTypeEntity.Name, 
                    BusinessType = enumType
                }));
        
            return values;
        }
        
        private static List<CompanyTypeDto> GetFirstRankClientTypes() => 
            Enum.GetValues(typeof(CompanyType))
                .Cast<CompanyType>()
                .Select(CompanyTypeDto.From)
                .ToList();
        
        private static List<GenderDto> GetGenders() => 
            Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(GenderDto.From)
                .ToList();
        
        private static List<EmployeesQuantityDto> GetEmployeesQuantities() => 
            Enum.GetValues(typeof(EmployeesSize))
                .Cast<EmployeesSize>()
                .Select(EmployeesQuantityDto.From)
                .ToList();

        private static IList<EmployeeStatusDto> GetEmployeeStatuses() => 
            Enum.GetValues(typeof(EmployeeStatus))
                .Cast<EmployeeStatus>()
                .Select(EmployeeStatusDto.From)
                .ToList();

        private static IList<ServiceTargetGroupDto> GetServiceTargetGroups() => 
            Enum.GetValues(typeof(ServiceTargetGroup))
                .Cast<ServiceTargetGroup>()
                .Select(ServiceTargetGroupDto.From)
                .ToList();
        
        private static IList<PolicyLookupDto> GetPolicies() => 
            Enum.GetValues(typeof(Policy))
                .Cast<Policy>()
                .Select(PolicyLookupDto.From)
                .ToList();
        
        private static IList<RoleDto> GetRoles() =>
            Enum.GetValues(typeof(SystemRole))
                .Cast<SystemRole>()
                .Select(RoleDto.From)
                .ToList();
        
        private static IList<ClientCategoryDto> GetClientCategories() =>
            Enum.GetValues(typeof(ClientCategory))
                .Cast<ClientCategory>()
                .Select(ClientCategoryDto.From)
                .ToList();

        private static IList<ColourDto> GetColours() => 
            Enum.GetValues(typeof(Colour))
                .Cast<Colour>()
                .Where(x => x != Colour.Grey)
                .OrderBy(x => x)
                .Select(ColourDto.From)
                .ToList();
        
        private static IList<BookingStateDto> GetBookingStates() =>
            Enum.GetValues(typeof(BookingState))
                .Cast<BookingState>()
                .Select(BookingStateDto.From)
                .ToList();
    }
}