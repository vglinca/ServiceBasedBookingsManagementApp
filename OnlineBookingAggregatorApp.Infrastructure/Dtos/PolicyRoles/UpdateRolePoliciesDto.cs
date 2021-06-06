using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles
{
    public class UpdateRolePoliciesDto
    {
        public long RoleId { get; set; }
        public IList<Policy> Policies { get; set; }
    }
}