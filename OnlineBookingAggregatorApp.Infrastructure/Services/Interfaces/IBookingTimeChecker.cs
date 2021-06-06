using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces
{
    public interface IBookingTimeChecker
    {
        Task CheckBookingCreatedAtEmployeeWorkTimeAsync(Booking booking);
        void CheckNoTimeOverlapForBookings(Booking bookingToAdd, List<Booking> existingBookings);
    }
}