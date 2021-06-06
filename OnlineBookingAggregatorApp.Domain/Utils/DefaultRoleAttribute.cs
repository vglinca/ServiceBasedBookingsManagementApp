using System;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Utils
{
    public class DefaultRoleAttribute : Attribute
    {
        public SystemRole[] Roles;

        public DefaultRoleAttribute(params SystemRole[] roles)
        {
            Roles = roles;
        }
    }
}