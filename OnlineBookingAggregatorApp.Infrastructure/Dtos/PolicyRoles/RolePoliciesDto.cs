using System.Collections.Generic;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles
{
    public class RolePoliciesDto
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public IList<PolicyDto> Policies { get; set; }
    }
}