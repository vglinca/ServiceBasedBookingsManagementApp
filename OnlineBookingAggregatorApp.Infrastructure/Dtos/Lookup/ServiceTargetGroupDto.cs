using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class ServiceTargetGroupDto : BaseLookupDto
    {
        public static ServiceTargetGroupDto From(ServiceTargetGroup src)
        {
            var entity = ServiceTargetGroupEntityFactory.Instance.Get(src);
            return new ServiceTargetGroupDto
            {
                Id = (long) entity.Id,
                Name = entity.Name
            };
        }
    }
}