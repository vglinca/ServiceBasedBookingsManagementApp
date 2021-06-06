using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Bookings
{
    public class UpdateBookingCommand : Command<(long, BookingUpdateDto)>
    {
        private readonly AppDbContext _dbContext;
        private readonly IBookingTimeChecker _bookingTimeChecker;

        public UpdateBookingCommand(AppDbContext dbContext, IBookingTimeChecker bookingTimeChecker)
        {
            _dbContext = dbContext;
            _bookingTimeChecker = bookingTimeChecker;
        }

        public override async Task ExecuteAsync((long, BookingUpdateDto) input)
        {
            var (bookingId, dto) = input;

            var booking = await _dbContext.Bookings.SingleByIdAsync(bookingId);

            booking.ServiceId = dto.ServiceId;
            booking.ClientId = dto.ClientId;
            booking.DateFrom = new DateTime(dto.DateFrom.Year, dto.DateFrom.Month, dto.DateFrom.Day, dto.HourFrom, dto.MinutesFrom, 0);
            booking.DateTo = new DateTime(dto.DateTo.Year, dto.DateTo.Month, dto.DateTo.Day, dto.HourTo, dto.MinutesTo, 0);
            if (!dto.IsFromResize)
            {
                booking.Comments = dto.Comments;
            }
            booking.SpecialistId = dto.SpecialistId;
            booking.Colour = dto.Colour;
            booking.State = dto.State;
            
            var year = dto.DateFrom.Year;
            var month = dto.DateFrom.Month;
            var day = dto.DateFrom.Day;
            
            var existingBookings = (await _dbContext.Bookings
                    .AsNoTracking()
                    .Where(x => x.DateFrom >= dto.DateFrom)
                    .Where(x => x.SpecialistId == dto.SpecialistId)
                    .Where(x => x.Id != bookingId)
                    .ToListAsync())
                .Where(x => x.DateFrom.Year == year && x.DateFrom.Month == month && x.DateFrom.Day == day)
                .ToList();
            

            await _bookingTimeChecker.CheckBookingCreatedAtEmployeeWorkTimeAsync(booking);
            
            if (existingBookings.Any() && existingBookings.Count > 1)
            {
                _bookingTimeChecker.CheckNoTimeOverlapForBookings(booking, existingBookings);
            }
        }
    }
}