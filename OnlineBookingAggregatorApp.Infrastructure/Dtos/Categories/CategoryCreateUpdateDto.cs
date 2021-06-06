using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories
{
    public class CategoryCreateUpdateDto
    {
        public string Name { get; set; }
        public BusinessArea BusinessArea { get; set; }
        public ServiceTargetGroup ServiceTargetGroup { get; set; }
    }
}