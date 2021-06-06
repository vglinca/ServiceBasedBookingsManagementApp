using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class EmployeesQuantityDto : BaseLookupDto
    {
        public static EmployeesQuantityDto From(EmployeesSize employeesSize)
        {
            var entity = EmployeesSizeEntityFactory.Instance.Get(employeesSize);

            return new EmployeesQuantityDto
            {
                Id = (long) entity.Id,
                Name = entity.Name
            };
        }
    }
}