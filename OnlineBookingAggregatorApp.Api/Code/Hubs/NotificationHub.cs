using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace OnlineBookingAggregatorApp.Api.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotificationHub: Hub
    {
        public async Task Notify(string userId, string message)
        {
            var user = Clients.User(userId);
            await Clients.User(userId).SendAsync("NotifySpecialist", message);
        }
    }
}