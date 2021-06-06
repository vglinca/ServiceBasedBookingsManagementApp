using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Bookings
{
    public class DeleteBookingCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteBookingCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync(long input)
        {
            var booking = await _dbContext.Bookings.SingleByIdAsync(input);

            if (booking.State == BookingState.Confirmed)
            {
                throw new InfrastructureInvalidOperationException("Can't delete confirmed booking.");
            }

            _dbContext.Bookings.Remove(booking);
        }
    }
}