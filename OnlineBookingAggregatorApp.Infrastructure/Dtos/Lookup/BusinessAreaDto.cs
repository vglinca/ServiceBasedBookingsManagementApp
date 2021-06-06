using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class BusinessAreaDto : BaseLookupDto
    {
        public BusinessType BusinessType { get; set; }
        public static BusinessAreaDto From(BusinessArea businessArea)
        {
            var businessAreaEntity = BusinessAreaEntityFactory.Instance.Get(businessArea);

            return new BusinessAreaDto
            {
                Id = (long) businessAreaEntity.Id,
                Name = businessAreaEntity.Name,
                BusinessType = (BusinessType) businessAreaEntity.ParentId
            };
        }
    }
}