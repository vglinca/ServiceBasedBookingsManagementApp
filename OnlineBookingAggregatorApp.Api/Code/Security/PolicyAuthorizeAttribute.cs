using System;
using Microsoft.AspNetCore.Authorization;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Api.Security
{
    public class PolicyAuthorizeAttribute : AuthorizeAttribute
    {
        public PolicyAuthorizeAttribute(Policy policy)
        {
            Policy = Enum.GetName(typeof(Policy), policy);
        }
    }
}