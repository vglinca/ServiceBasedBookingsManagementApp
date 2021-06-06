using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Role : IdentityRole<long>
    {
        public Role()
        {
        }

        public Role(string name) : base(name)
        {
            
        }
    }
}