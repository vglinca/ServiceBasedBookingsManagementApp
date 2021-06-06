using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Bookings
{
    public class AddBookingCommand : Command<(long, BookingCreateDto), Booking>
    {
        private readonly AppDbContext _dbContext;
        private readonly IBookingTimeChecker _bookingTimeChecker;
        private const int Columns = 96;

        public AddBookingCommand(AppDbContext dbContext, IBookingTimeChecker bookingTimeChecker)
        {
            _dbContext = dbContext;
            _bookingTimeChecker = bookingTimeChecker;
        }

        public override async Task<Booking> ExecuteAsync((long, BookingCreateDto) input)
        {
            var (companyId, dto) = input;
            var specialist = await _dbContext.Users
                .AsNoTracking()
                .Include(x => x.ServiceEmployees)
                .FirstUserByIdAsync(dto.SpecialistId);

            if (!specialist.ServiceEmployees.Select(x => x.ServiceId).Contains(dto.ServiceId))
            {
                throw new BadRequestException($"Specialist {specialist.FirstName} {specialist.LastName} does not render this service");
            }
            
            Booking booking;

            if (dto.ClientId == 0)
            {
                booking = await CreateClientAndAddBooking(dto, companyId);
                return booking;
            }

            var client = await _dbContext.Clients.SingleByIdOrDefaultAsync(dto.ClientId);
            booking = await CreateBooking(dto, client);

            return booking;
        }

        private async Task<Booking> CreateClientAndAddBooking(BookingCreateDto input, long companyId)
        {
            var client = new Client(input.ClientFirstName, input.ClientLastName,
                input.ClientPhone, null, input.ClientEmail, ClientCategory.Loyal,
                input.Gender, input.ClientBirthDate, input.Comments, companyId);

            await _dbContext.Clients.AddAsync(client);

            return await CreateBooking(input, client);
        }

        private async Task<Booking> CreateBooking(BookingCreateDto input, Client client)
        {
            var booking = new Booking
            {
                ServiceId = input.ServiceId,
                DateFrom = new DateTime(input.DateFrom.Year, input.DateFrom.Month, input.DateFrom.Day, input.HourFrom, 
                    input.MinutesFrom, 0),
                DateTo = new DateTime(input.DateTo.Year, input.DateTo.Month, input.DateTo.Day, input.HourTo, 
                    input.MinutesTo, 0),
                Comments = input.Comments,
                SpecialistId = input.SpecialistId,
                Client = client,
                Colour = input.Colour,
                State = BookingState.WaitingForClient
            };

            var year = input.DateFrom.Year;
            var month = input.DateFrom.Month;
            var day = input.DateFrom.Day;

            var existingBookings = (await _dbContext.Bookings
                    .AsNoTracking()
                    .Where(x => x.DateFrom >= input.DateFrom)
                    .Where(x => x.SpecialistId == input.SpecialistId)
                    .ToListAsync())
                .Where(x => x.DateFrom.Year == year && x.DateFrom.Month == month && x.DateFrom.Day == day)
                .ToList();

            if (!existingBookings.Any())
            {
                await _bookingTimeChecker.CheckBookingCreatedAtEmployeeWorkTimeAsync(booking);
                await _dbContext.Bookings.AddAsync(booking);
                return booking;
            }

            await _bookingTimeChecker.CheckBookingCreatedAtEmployeeWorkTimeAsync(booking);
            _bookingTimeChecker.CheckNoTimeOverlapForBookings(booking, existingBookings);

            await _dbContext.Bookings.AddAsync(booking);

            return booking;
        }

        private async Task EnsureBookingsCreatedAtWorkTime(Booking newBooking)
        {
            var specialist = await _dbContext.Users.SingleUserByIdAsync(newBooking.SpecialistId);
            var workSchedules = (await _dbContext.WeekDayWorkSchedules
                    .AsNoTracking()
                    .Include(x => x.WorkSchedule)
                    .Where(x => x.WorkSchedule.EmployeeId == specialist.Id)
                    .ToListAsync())
                .Where(x => (long) x.DayOfWeek - 1 == (long) newBooking.DateFrom.DayOfWeek)
                .Select(x => x.WorkSchedule)
                .OrderBy(x => x.WorkingHoursFrom)
                .ToList();
            
            var works = new bool[Columns];
            var bookingCells = new bool[Columns];
            for (var i = 0; i < Columns; i++)
            {
                bookingCells[i] = false;
                works[i] = false;
            }
            
            for (var d = newBooking.DateFrom; d < newBooking.DateTo; d = d.AddMinutes(15))
            {
                var index = d.Hour * 4 + d.Minute / 15;
                bookingCells[index] = true;
            }
            
            foreach (var ws in workSchedules)
            {
                var workStartDateTime = new DateTime(newBooking.DateFrom.Year, newBooking.DateFrom.Month,
                    newBooking.DateFrom.Day, ws.WorkingHoursFrom, ws.WorkingMinutesFrom, 0);
                var workEndDateTime = new DateTime(newBooking.DateFrom.Year, newBooking.DateFrom.Month,
                    newBooking.DateFrom.Day, ws.WorkingHoursTo, ws.WorkingMinutesTo, 0);
                for (var d = workStartDateTime; d < workEndDateTime; d = d.AddMinutes(15))
                {
                    var index = d.Hour * 4 + d.Minute / 15;
                    works[index] = true;
                }
            }
           
            var bookingStartsAtColumnIndex = newBooking.DateFrom.Hour * 4 + newBooking.DateFrom.Minute / 15;
            var bookingEndsAtColumnIndex = newBooking.DateTo.Hour * 4 + newBooking.DateTo.Minute / 15;

            for (var i = bookingStartsAtColumnIndex; i < bookingEndsAtColumnIndex; i++)
            {
                if (!works[i] && bookingCells[i])
                {
                    throw new BadRequestException($"Specialist doesn't work in the selected time slot.");
                }
            }
        }

        private static void EnsureNoTimeOverlapForBookings(Booking newBooking, List<Booking> existingBookings)
        {
            var bookings = existingBookings.Union(new[] {newBooking})
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
    }
}