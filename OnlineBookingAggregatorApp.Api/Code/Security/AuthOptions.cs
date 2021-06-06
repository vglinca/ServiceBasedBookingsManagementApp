using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OnlineBookingAggregatorApp.Api.Security
{
    public class AuthOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenLifetime { get; set; }
        
        public SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.ASCII.GetBytes(Secret));
    }
}