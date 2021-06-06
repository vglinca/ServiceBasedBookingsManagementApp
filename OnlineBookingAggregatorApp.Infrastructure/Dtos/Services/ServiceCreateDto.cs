using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Services
{
    public class ServiceCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public IList<long> EmployeeIds { get; set; } = new List<long>();
    }
}