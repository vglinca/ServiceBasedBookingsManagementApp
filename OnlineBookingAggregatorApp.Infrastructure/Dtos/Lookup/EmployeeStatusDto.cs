using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class EmployeeStatusDto : BaseLookupDto
    {
        public string Description { get; set; }
        public string Icon { get; set; }

        public static EmployeeStatusDto From(EmployeeStatus employeeStatus)
        {
            var entity = EmployeeStatusEntityFactory.Instance.Get(employeeStatus);

            return new EmployeeStatusDto
            {
                Id = (long) entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Icon = entity.Icon
            };
        }
    }
}