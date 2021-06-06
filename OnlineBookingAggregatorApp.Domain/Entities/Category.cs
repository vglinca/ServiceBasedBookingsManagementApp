using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public BusinessArea BusinessArea { get; set; }
        public ServiceTargetGroup ServiceTargetGroup { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public Category() {}
    }
}