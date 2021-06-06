using Microsoft.AspNetCore.Authorization;

namespace OnlineBookingAggregatorApp.Api.Security
{
    public class PolicyAssigned : IAuthorizationRequirement
    {
        public PolicyAssigned(string policyName)
        {
            PolicyName = policyName;
        }

        public string PolicyName { get; }
    }
}