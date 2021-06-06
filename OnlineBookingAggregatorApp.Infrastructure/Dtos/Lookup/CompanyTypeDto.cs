using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class CompanyTypeDto : BaseLookupDto
    {
        public static CompanyTypeDto From(CompanyType serviceType)
        {
            var serviceTypeEntity = CompanyTypeEntityFactory.Instance.Get(serviceType);

            return new CompanyTypeDto
            {
                Id = (long) serviceTypeEntity.Id,
                Name = serviceTypeEntity.Name
            };
        }
    }
}