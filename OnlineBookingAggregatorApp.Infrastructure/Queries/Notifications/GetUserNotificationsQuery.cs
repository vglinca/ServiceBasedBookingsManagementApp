using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Notifications;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;
// ReSharper disable All

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Notifications
{
    public class GetUserNotificationsQuery : Query<long, IList<NotificationDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetUserNotificationsQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<NotificationDto>> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            await _dbContext.Users.AssertUserExistsAsync(input, cancellationToken);
            var notifications = await _dbContext.Notifications
                .AsNoTracking()
                .Where(x => x.ReceiverId == input)
                .Select(x => NotificationDto.From(x))
                .ToListAsync(cancellationToken);

            return notifications;
        }
    }
}