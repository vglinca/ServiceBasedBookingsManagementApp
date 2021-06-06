using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class RoleDto : BaseLookupDto
    {
        public static RoleDto From(SystemRole role)
        {
            var roleEntity = SystemRoleEntityFactory.Instance.Get(role);
            return new RoleDto
            {
                Id = (long) roleEntity.Id,
                Name = roleEntity.Name
            };
        }
    }
}