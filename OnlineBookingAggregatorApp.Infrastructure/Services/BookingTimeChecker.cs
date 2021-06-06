using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Services
{
    public class BookingTimeChecker : IBookingTimeChecker
    {
        private const int Columns = 96;
        private readonly AppDbContext _dbContext;

        public BookingTimeChecker(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CheckBookingCreatedAtEmployeeWorkTimeAsync(Booking booking)
        {
            var specialist = await _dbContext.Users.SingleUserByIdAsync(booking.SpecialistId);
            var workSchedules = (await _dbContext.WeekDayWorkSchedules
                    .AsNoTracking()
                    .Include(x => x.WorkSchedule)
                    .Where(x => x.WorkSchedule.EmployeeId == specialist.Id)
                    .ToListAsync())
                .Where(x => (long) x.DayOfWeek - 1 == (long) booking.DateFrom.DayOfWeek)
                .Select(x => x.WorkSchedule)
                .OrderBy(x => x.WorkingHoursFrom)
                .ToList();

            if (!workSchedules.Any())
            {
                throw new BadRequestException($"Specialist doesn't work in the selected time range.");
            }
            
            var works = new bool[Columns];
            var bookingCells = new bool[Columns];
            for (var i = 0; i < Columns; i++)
            {
                bookingCells[i] = false;
                works[i] = false;
            }
            
            for (var d = booking.DateFrom; d < booking.DateTo; d = d.AddMinutes(15))
            {
                var index = d.Hour * 4 + d.Minute / 15;
                bookingCells[index] = true;
            }
            
            foreach (var ws in workSchedules)
            {
                var workStartDateTime = new DateTime(booking.DateFrom.Year, booking.DateFrom.Month,
                    booking.DateFrom.Day, ws.WorkingHoursFrom, ws.WorkingMinutesFrom, 0);
                var workEndDateTime = new DateTime(booking.DateFrom.Year, booking.DateFrom.Month,
                    booking.DateFrom.Day, ws.WorkingHoursTo, ws.WorkingMinutesTo, 0);
                for (var d = workStartDateTime; d < workEndDateTime; d = d.AddMinutes(15))
                {
                    var index = d.Hour * 4 + d.Minute / 15;
                    works[index] = true;
                }
            }
           
            var bookingStartsAtColumnIndex = booking.DateFrom.Hour * 4 + booking.DateFrom.Minute / 15;
            var bookingEndsAtColumnIndex = booking.DateTo.Hour * 4 + booking.DateTo.Minute / 15;

            for (var i = bookingStartsAtColumnIndex; i < bookingEndsAtColumnIndex; i++)
            {
                if (!works[i] && bookingCells[i])
                {
                    throw new BadRequestException($"Specialist doesn't work in the selected time range.");
                }
            }
        }

        public void CheckNoTimeOverlapForBookings(Booking bookingToAdd, List<Booking> existingBookings)
        {
            var bookings = existingBookings.Union(new[] {bookingToAdd})
                .OrderBy(x => x.DateFrom)
                .ToList();
            
            var rows = bookings.Count;

            var scheduleMatrix = new bool[rows][];
            for (var i = 0; i < rows; i++)
            {
                scheduleMatrix[i] = new bool[Columns];
                for (var j = 0; j < Columns; j++)
                {
                    scheduleMatrix[i][j] = true;
                }
            }

            for (var i = 0; i < rows; i++)
            {
                var booking = bookings[i];
                for (var d = booking.DateFrom; d < booking.DateTo; d = d.AddMinutes(15))
                {
                    var col = d.Hour * 4 + d.Minute / 15;
                    scheduleMatrix[i][col] = false;
                }
            }

            for (var k = 0; k < rows; k++)
            {
                var booking = bookings[k];
                var bookingStartsAtColumnIndex = booking.DateFrom.Hour * 4 + booking.DateFrom.Minute / 15;
                var bookingEndsAtColumnIndex = booking.DateTo.Hour * 4 + booking.DateTo.Minute / 15 - 1;

                for (var i = 0; i < rows; i++)
                {
                    if(i == k) continue;
                    for (var j = bookingStartsAtColumnIndex; j < bookingEndsAtColumnIndex; j++)
                    {
                        if (!scheduleMatrix[i][j])
                        {
                            throw new BadRequestException("There is already a booking for this time.");
                        }
                    }
                }
            }
        }
        
        private static (int, int) GetTimeFromColumnIndex(int index)
        {
            if (index % 4 == 0)
            {
                return (index / 4, 0);
            }

            if (index % 4 != 0 && index % 2 == 0)
            {
                return (index / 4, 30);
            }

            if (index % 2 != 0 && (index + 1) % 4 == 0)
            {
                return (index / 4, 45);
            }

            return (index / 4, 15);
        }
    }
}