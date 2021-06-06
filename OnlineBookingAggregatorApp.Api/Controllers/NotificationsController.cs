using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Notifications;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Notifications;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Notifications;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : BaseController
    {
        [HttpGet("for-user/{userId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<IList<NotificationDto>>> GetForUser([FromRoute] long userId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetUserNotificationsQuery, long, IList<NotificationDto>>(userId, cancellationToken);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> Add([FromBody] NotificationCreateDto input)
        {
            return ExecuteCommandReturningEntityId<CreateNotificationCommand, NotificationCreateDto, Notification>(input);
        }
    }
}