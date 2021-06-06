using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class PolicyRole : Entity
    {
        public Policy Policy { get; }
        public SystemRole Role { get; }
        public bool IsSetByDefault { get; }

        public PolicyRole() { }

        public PolicyRole(Policy policy, SystemRole role, bool isSetByDefault = true)
        {
            Policy = policy;
            Role = role;
            IsSetByDefault = isSetByDefault;
        }
    }
}