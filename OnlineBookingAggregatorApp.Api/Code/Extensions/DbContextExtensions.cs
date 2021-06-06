using System;
using System.Linq;
using System.Reflection;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Domain.Utils;
using OnlineBookingAggregatorApp.Persistence.Data;
// ReSharper disable All

namespace OnlineBookingAggregatorApp.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static void SeedPolicies(this AppDbContext ctx)
        {
            var policies = Enum.GetValues(typeof(Policy))
                .Cast<Policy>()
                .ToList();

            foreach (var policy in policies)
            {
                var memberInfo = policy.GetType().GetMember(policy.ToString());
                ProcessPolicy(ctx, memberInfo, policy);
            }

            ctx.SaveChanges();
        }

        private static void ProcessPolicy(AppDbContext ctx, MemberInfo[] memberInfo, Policy policy)
        {
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DefaultRoleAttribute), false);
            if (!attributes.Any())
            {
                return;
            }
            
            var roles = ((DefaultRoleAttribute) attributes[0]).Roles;
            foreach (var role in roles)
            {
                if (ctx.PolicyRoles.Any(x => x.Policy == policy && x.Role == role))
                {
                    continue;
                }
                
                var policyRole = new PolicyRole(policy, role);
                ctx.PolicyRoles.Add(policyRole);
            }
        }
    }
}