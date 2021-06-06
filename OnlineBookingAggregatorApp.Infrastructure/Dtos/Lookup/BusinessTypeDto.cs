using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class BusinessTypeDto : BaseLookupDto
    {
        public static BusinessTypeDto From(BusinessType businessType)
        {
            var serviceTypeEntity = BusinessTypeEntityFactory.Instance.Get(businessType);

            return new BusinessTypeDto
            {
                Id = (long) serviceTypeEntity.Id,
                Name = serviceTypeEntity.Name
            };
        }
    }
}