using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum ServiceTargetGroup
    {
        ForMen = 1,
        ForWomen,
        General
    }

    public class ServiceTargetGroupEntity : EnumEntity<ServiceTargetGroup>
    {
        public ServiceTargetGroupEntity() { }
        public ServiceTargetGroupEntity(ServiceTargetGroup id, string name): base(id, name) { }
    }

    public class ServiceTargetGroupEntityFactory : EnumEntityFactory<ServiceTargetGroup, ServiceTargetGroupEntity>
    {
        public static ServiceTargetGroupEntityFactory Instance { get; } = new ServiceTargetGroupEntityFactory();

        public ServiceTargetGroupEntityFactory()
        {
            Register(
                new ServiceTargetGroupEntity(ServiceTargetGroup.ForMen, "Men's"),
                new ServiceTargetGroupEntity(ServiceTargetGroup.ForWomen, "Women's"),
                new ServiceTargetGroupEntity(ServiceTargetGroup.General, "General"));
        }
    }
}