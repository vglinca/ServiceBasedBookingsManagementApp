using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Bookings;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class BookingsController : BaseController
    {
        [HttpGet("{bookingId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<BookingDto>> GetBookingById([FromRoute] long bookingId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetBookingByIdQuery, long, BookingDto>(bookingId, cancellationToken);
        }

        [HttpGet("for-dashboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<IList<BookingDto>>> GetForDashboard([FromQuery] GetBookingsForDashboardQueryInputDto input,
            CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetBookingsForDashboardQuery, GetBookingsForDashboardQueryInputDto, IList<BookingDto>>(input, cancellationToken);
        }

        [HttpGet("paged/{companyId:long}")]
        [PolicyAuthorize(Policy.ViewAllBookings)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<PagedResult<BookingPagedDto>>> GetPaged([FromRoute] long companyId,
            [FromQuery] PagedRequest request, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetBookingsPagedQuery, (long, PagedRequest), PagedResult<BookingPagedDto>>((companyId, request), cancellationToken);
        }

        [HttpPost("{companyId:long}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> Create([FromRoute] long companyId, [FromBody] BookingCreateDto input)
        {
            return ExecuteCommandReturningEntityId<AddBookingCommand, (long, BookingCreateDto), Booking>((companyId, input));
        }

        [HttpPut("{bookingId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult> Update([FromRoute] long bookingId, [FromBody] BookingUpdateDto input)
        {
            return ExecuteCommand<UpdateBookingCommand, (long, BookingUpdateDto)>((bookingId, input));
        }

        [HttpDelete("{bookingId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult> Delete([FromRoute] long bookingId)
        {
            return ExecuteCommand<DeleteBookingCommand, long>(bookingId);
        }
    }
}