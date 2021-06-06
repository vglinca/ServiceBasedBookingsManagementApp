using System.Collections.Generic;
using System.Linq;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Employees
{
    public class EmployeeForSelectDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public long? PositionId { get; set; }
        public IList<long> ServicesIds { get; set; }

        public static EmployeeForSelectDto From(User src) => new EmployeeForSelectDto
        {
            Id = src.Id,
            FirstName = src.FirstName,
            LastName = src.LastName,
            PositionId = src.PositionId,
            ServicesIds = src.ServiceEmployees.Select(y => y.ServiceId).ToList()
        };
    }
}