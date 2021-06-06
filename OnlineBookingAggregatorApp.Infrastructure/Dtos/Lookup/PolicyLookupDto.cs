using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class PolicyLookupDto : BaseLookupDto
    {
        public static PolicyLookupDto From(Policy policy)
        {
            var entity = PolicyEntityFactory.Instance.Get(policy);
            return new PolicyLookupDto
            {
                Id = (long) entity.Id,
                Name = entity.Name
            };
        }
    }
}