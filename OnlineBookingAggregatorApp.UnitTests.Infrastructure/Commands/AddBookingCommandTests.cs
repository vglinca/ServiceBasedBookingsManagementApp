using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Infrastructure.Services;
using OnlineBookingAggregatorApp.Persistence.Data;
using Xunit;

namespace OnlineBookingAggregatorApp.UnitTests.Infrastructure.Commands
{
    public class AddBookingCommandTests
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly IList<Booking> _bookings;

        private Booking _booking1;
        private Booking _booking2;
        private Booking _booking3;
        private Booking _booking4;
        private Booking _booking5;
        private Booking _booking6;
        private Booking _booking7;
        private Booking _booking8;
        private Booking _booking9;
        private Booking _booking10;

        private User _user1;
        private User _user2;
        private User _user3;

        private Client _client1;
        private Client _client2;
        private Client _client3;
        private Client _client4;
        private Client _client5;
        private Client _client6;

        private Company _company;
        private Service _service;

        private WorkSchedule _user1Ws1;
        private WorkSchedule _user2Ws1;
        private WorkSchedule _user2Ws2;
        private WorkSchedule _user3Ws1;
        private WorkSchedule _user3Ws2;

        public AddBookingCommandTests()
        {
            _bookings = new List<Booking>();
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(nameof(AddBookingCommandTests))
                .Options;

            using var dbContext = new AppDbContext(_options);
            dbContext.Database.EnsureCreated();
            SetupData(dbContext);
        }

        [Fact]
        public async Task AddBooking_ShouldSucceed()
        {
            var newBooking = new BookingCreateDto()
            {
                ClientId = _client4.Id,
                ServiceId = _service.Id,
                SpecialistId = _user1.Id,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                HourFrom = 11,
                MinutesFrom = 30,
                HourTo = 12,
                MinutesTo = 30,
                Colour = Colour.Amber
            };
            
            await using var dbContext = new AppDbContext(_options);
            var timeCheckerService = new BookingTimeChecker(dbContext);
            var command = new AddBookingCommand(dbContext, timeCheckerService);

            var result = await command.ExecuteAsync((_company.Id, newBooking));
            
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task AddBooking_ForTimeWhenThereIsABooking_ShouldFail()
        {
            var newBooking = new BookingCreateDto()
            {
                ClientId = _client4.Id,
                ServiceId = _service.Id,
                SpecialistId = _user1.Id,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                HourFrom = 9,
                HourTo = 10,
                MinutesFrom = 30,
                MinutesTo = 45,
                Colour = Colour.Amber
            };
            
            await using var dbContext = new AppDbContext(_options);
            var timeCheckerService = new BookingTimeChecker(dbContext);
            var command = new AddBookingCommand(dbContext, timeCheckerService);

            var ex = await Assert.ThrowsAsync<BadRequestException>(async () =>
                await command.ExecuteAsync((_company.Id, newBooking)));
            Assert.Equal("There is already a booking for this time.", ex.Message);
        }

        [Fact]
        public async Task AddBooking_ForServiceThatSpecialistDoesNotRender_ShouldFail()
        {
            var newBooking = new BookingCreateDto()
            {
                ClientId = _client4.Id,
                ServiceId = 3,
                SpecialistId = _user1.Id,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                HourFrom = 9,
                HourTo = 10,
                MinutesFrom = 30,
                MinutesTo = 45,
                Colour = Colour.Amber
            };
            
            await using var dbContext = new AppDbContext(_options);
            var timeCheckerService = new BookingTimeChecker(dbContext);
            var command = new AddBookingCommand(dbContext, timeCheckerService);
            
            var ex = await Assert.ThrowsAsync<BadRequestException>(async () =>
                await command.ExecuteAsync((_company.Id, newBooking)));
            Assert.Equal($"Specialist {_user1.FirstName} {_user1.LastName} does not render this service", ex.Message);
        }

        [Fact]
        public async Task AddBookings_ForTimeWhenSpecialistDoesNotWork_ShouldFail()
        {
            var newBooking = new BookingCreateDto()
            {
                ClientId = _client4.Id,
                ServiceId = _service.Id,
                SpecialistId = _user1.Id,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                HourFrom = 13,
                HourTo = 14,
                MinutesFrom = 30,
                MinutesTo = 45,
                Colour = Colour.Amber
            };
            
            await using var dbContext = new AppDbContext(_options);
            var timeCheckerService = new BookingTimeChecker(dbContext);
            var command = new AddBookingCommand(dbContext, timeCheckerService);
            
            var ex = await Assert.ThrowsAsync<BadRequestException>(async () =>
                await command.ExecuteAsync((_company.Id, newBooking)));
            Assert.Equal("Specialist doesn't work in the selected time range.", ex.Message);
        }

        private void SetupData(AppDbContext dbContext)
        {
            _user1 = new User {FirstName = "Vlada", LastName = "Izotova"};
            _user2 = new User {FirstName = "Dan", LastName = "Wang"};
            _user3 = new User {FirstName = "Jari", LastName = "Maenpaa"};

            dbContext.Users.Add(_user1);
            dbContext.Users.Add(_user2);
            dbContext.Users.Add(_user3);

            _service = new Service
            {
                Name = "Service"
            };

            dbContext.Services.Add(_service);

            var serviceEmployee = new ServiceEmployee
            {
                ServiceId = _service.Id,
                EmployeeId = _user1.Id
            };

            dbContext.ServiceEmployees.Add(serviceEmployee);

            _user1Ws1 = new WorkSchedule
            {
                EmployeeId = _user1.Id,
                WorkingHoursFrom = 9,
                WorkingMinutesFrom = 0,
                WorkingHoursTo = 14,
                WorkingMinutesTo = 0
            };
            _user2Ws1 = new WorkSchedule
            {
                EmployeeId = _user2.Id,
                WorkingHoursFrom = 10,
                WorkingMinutesFrom = 30,
                WorkingHoursTo = 14,
                WorkingMinutesTo = 0
            };
            _user2Ws2 = new WorkSchedule
            {
                EmployeeId = _user2.Id,
                WorkingHoursFrom = 15,
                WorkingMinutesFrom = 0,
                WorkingHoursTo = 19,
                WorkingMinutesTo = 0
            };
            _user3Ws1 = new WorkSchedule
            {
                EmployeeId = _user3.Id,
                WorkingHoursFrom = 8,
                WorkingMinutesFrom = 0,
                WorkingHoursTo = 13,
                WorkingMinutesTo = 0
            };
            _user3Ws2 = new WorkSchedule
            {
                EmployeeId = _user3.Id,
                WorkingHoursFrom = 14,
                WorkingMinutesFrom = 0,
                WorkingHoursTo = 18,
                WorkingMinutesTo = 0
            };

            dbContext.WorkSchedules.Add(_user1Ws1);
            dbContext.WorkSchedules.Add(_user2Ws1);
            dbContext.WorkSchedules.Add(_user2Ws2);
            dbContext.WorkSchedules.Add(_user3Ws1);
            dbContext.WorkSchedules.Add(_user3Ws2);

            var weekDayWorkSchedules = new List<WeekDayWorkSchedule>
            {
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Monday
                },
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Tuesday
                },
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Wednesday
                },
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Thursday
                },
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Friday
                },
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Saturday
                },
                new()
                {
                    WorkScheduleId = _user1Ws1.Id,
                    DayOfWeek = WeekDay.Sunday
                },
                new()
                {
                    WorkScheduleId = _user2Ws1.Id,
                    DayOfWeek = WeekDay.Tuesday
                },
                new()
                {
                    WorkScheduleId = _user2Ws1.Id,
                    DayOfWeek = WeekDay.Thursday
                },
                new()
                {
                    WorkScheduleId = _user2Ws1.Id,
                    DayOfWeek = WeekDay.Friday
                },
                new()
                {
                    WorkScheduleId = _user2Ws2.Id,
                    DayOfWeek = WeekDay.Tuesday
                },
                new()
                {
                    WorkScheduleId = _user2Ws2.Id,
                    DayOfWeek = WeekDay.Thursday
                },
                new()
                {
                    WorkScheduleId = _user2Ws2.Id,
                    DayOfWeek = WeekDay.Friday
                },
                new()
                {
                    WorkScheduleId = _user3Ws1.Id,
                    DayOfWeek = WeekDay.Monday
                },
                new()
                {
                    WorkScheduleId = _user3Ws1.Id,
                    DayOfWeek = WeekDay.Wednesday
                },
                new()
                {
                    WorkScheduleId = _user3Ws1.Id,
                    DayOfWeek = WeekDay.Friday
                },
                new()
                {
                    WorkScheduleId = _user3Ws2.Id,
                    DayOfWeek = WeekDay.Monday
                },
                new()
                {
                    WorkScheduleId = _user3Ws2.Id,
                    DayOfWeek = WeekDay.Wednesday
                },
                new()
                {
                    WorkScheduleId = _user3Ws2.Id,
                    DayOfWeek = WeekDay.Friday
                }
            };
            
            dbContext.WeekDayWorkSchedules.AddRange(weekDayWorkSchedules);

            _company = new Company
            {
                Name = "Company",
                CompanyType = CompanyType.JuridicalPerson,
                BusinessType = BusinessType.Auto,
                EmployeesSize = EmployeesSize.FromElevenToTwenty
            };

            dbContext.Companies.Add(_company);

            _client1 = new Client
            {
                FirstName = "James",
                LastName = "McKenzee",
                PhoneNumber = "12345678",
                Email = "james.mckenzee@email.com",
                ClientCategory = ClientCategory.VIP,
                CompanyId = _company.Id
            };
            _client2 = new Client
            {
                FirstName = "Steve",
                LastName = "Brown",
                PhoneNumber = "12345678",
                Email = "steve.brown@email.com",
                ClientCategory = ClientCategory.Permanent,
                CompanyId = _company.Id
            };
            _client3 = new Client
            {
                FirstName = "Dave",
                LastName = "Ptacec",
                PhoneNumber = "12345678",
                Email = "dave.ptacec@email.com",
                ClientCategory = ClientCategory.Permanent,
                CompanyId = _company.Id
            };
            _client4 = new Client
            {
                FirstName = "Patryk",
                LastName = "Wagner",
                PhoneNumber = "12345678",
                Email = "patryk.wagner@email.com",
                ClientCategory = ClientCategory.VIP,
                CompanyId = _company.Id
            };
            _client5 = new Client
            {
                FirstName = "Chuck",
                LastName = "Schuldiner",
                PhoneNumber = "12345678",
                Email = "chuck.schuldiner@email.com",
                ClientCategory = ClientCategory.Permanent,
                CompanyId = _company.Id
            };
            _client6 = new Client
            {
                FirstName = "Glen",
                LastName = "Benton",
                PhoneNumber = "12345678",
                Email = "glen.benton@deicide.com",
                ClientCategory = ClientCategory.VIP,
                CompanyId = _company.Id
            };

            dbContext.Clients.Add(_client1);
            dbContext.Clients.Add(_client2);
            dbContext.Clients.Add(_client3);
            dbContext.Clients.Add(_client4);
            dbContext.Clients.Add(_client5);
            dbContext.Clients.Add(_client6);
            
            _booking1 = new Booking
            {
                ClientId = _client1.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 45, 0),
                Comments = string.Empty,
                SpecialistId = _user1.Id,
                State = BookingState.Confirmed
            };
            _booking2 = new Booking
            {
                ClientId = _client2.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0),
                Comments = string.Empty,
                SpecialistId = _user1.Id,
                State = BookingState.Confirmed
            };
            _booking3 = new Booking
            {
                ClientId = _client3.Id,
                ServiceId = 2,
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 15, 0),
                DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 30, 0),
                Comments = string.Empty,
                SpecialistId = _user2.Id,
                State = BookingState.Confirmed
            };
            _booking4 = new Booking
            {
                ClientId = _client1.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 10, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 11, 15, 0),
                Comments = string.Empty,
                SpecialistId = _user1.Id,
                State = BookingState.Confirmed
            };
            _booking5 = new Booking
            {
                ClientId = _client4.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 13, 0, 0),
                Comments = string.Empty,
                SpecialistId = _user3.Id,
                State = BookingState.Confirmed
            };
            _booking6 = new Booking
            {
                ClientId = _client5.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 15, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 16, 0, 0),
                Comments = string.Empty,
                SpecialistId = _user3.Id,
                State = BookingState.Confirmed
            };
            _booking7 = new Booking
            {
                ClientId = _client6.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 17, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 17, 45, 0),
                Comments = string.Empty,
                SpecialistId = _user3.Id,
                State = BookingState.Confirmed
            };
            _booking8 = new Booking
            {
                ClientId = _client4.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(2).Year, DateTime.Now.AddDays(2).Month, DateTime.Now.AddDays(2).Day, 9, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(2).Year, DateTime.Now.AddDays(2).Month, DateTime.Now.AddDays(2).Day, 10, 0, 0),
                Comments = string.Empty,
                SpecialistId = _user1.Id,
                State = BookingState.Confirmed
            };
            _booking9 = new Booking
            {
                ClientId = _client3.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(-1).Year, DateTime.Now.AddDays(-1).Month, DateTime.Now.AddDays(-1).Day, 9, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(-1).Year, DateTime.Now.AddDays(-1).Month, DateTime.Now.AddDays(-1).Day, 9, 45, 0),
                Comments = string.Empty,
                SpecialistId = _user2.Id,
                State = BookingState.Confirmed
            };
            _booking10 = new Booking
            {
                ClientId = _client6.Id,
                ServiceId = 1,
                DateFrom = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 9, 0, 0),
                DateTo = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 9, 45, 0),
                Comments = string.Empty,
                SpecialistId = _user2.Id,
                State = BookingState.Confirmed
            };
            
            _bookings.Add(_booking1);
            _bookings.Add(_booking2);
            _bookings.Add(_booking3);
            _bookings.Add(_booking4);
            _bookings.Add(_booking5);
            _bookings.Add(_booking6);
            _bookings.Add(_booking7);
            _bookings.Add(_booking8);
            _bookings.Add(_booking9);
            _bookings.Add(_booking10);
            
            dbContext.Bookings.Add(_booking1);
            dbContext.Bookings.Add(_booking2);
            dbContext.Bookings.Add(_booking3);
            dbContext.Bookings.Add(_booking4);
            dbContext.Bookings.Add(_booking5);
            dbContext.Bookings.Add(_booking6);
            dbContext.Bookings.Add(_booking7);
            dbContext.Bookings.Add(_booking8);
            dbContext.Bookings.Add(_booking9);
            dbContext.Bookings.Add(_booking10);
            
            dbContext.SaveChanges();
        }
    }
}