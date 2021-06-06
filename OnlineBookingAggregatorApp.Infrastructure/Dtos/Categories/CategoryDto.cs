using System;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public BusinessArea BusinessAreaId { get; set; }
        public string BusinessArea { get; set; }
        public ServiceTargetGroup ServiceTargetGroupId { get; set; }
        public string ServiceTargetGroup { get; set; }
        public int TotalServices { get; set; }

        public static CategoryDto From(Category src) => new()
        {
            Id = src.Id,
            Name = src.Name,
            BusinessAreaId = src.BusinessArea,
            BusinessArea = Enum.GetName(typeof(BusinessArea), src.BusinessArea),
            ServiceTargetGroupId = src.ServiceTargetGroup,
            ServiceTargetGroup = Enum.GetName(typeof(ServiceTargetGroup), src.ServiceTargetGroup)
        };
    }
}