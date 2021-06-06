using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Bookings;
using OnlineBookingAggregatorApp.Persistence.Data;
using Xunit;

namespace OnlineBookingAggregatorApp.UnitTests.Infrastructure.Queries
{
    public class GetBookingsForDashboardQueryTests
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

        public GetBookingsForDashboardQueryTests()
        {
            _bookings = new List<Booking>();
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(nameof(GetBookingsForDashboardQueryTests))
                .Options;

            using var dbContext = new AppDbContext(_options);
            dbContext.Database.EnsureCreated();
            SetupData(dbContext);
        }

        [Fact]
        public async Task GetBookingForDashboardQuery_ReturnsBookingsForNeededSpecialists()
        {
            await using var dbContext = new AppDbContext(_options);
            var query = new GetBookingsForDashboardQuery(dbContext);
            var specialistsIds = new List<long> {_user1.Id, _user3.Id};
            var inputDto = new GetBookingsForDashboardQueryInputDto
            {
                CompanyId = _company.Id,
                DateFrom = DateTime.Now.Date,
                DateTo = DateTime.Now.AddDays(1).Date,
                SpecialistsIds = specialistsIds
            };

            var result = await query.ExecuteAsync(inputDto);
            
            Assert.NotNull(result);
            Assert.True(result.Select(x => x.SpecialistId).All(x => specialistsIds.Contains(x)));
        }

        [Fact]
        public async Task GetBookingsForDashboardQuery_ReturnsBookingsForSpecifiedDateRange()
        {
            var dateFrom = DateTime.Now.AddDays(-1).Date;
            var dateTo = DateTime.Now.AddDays(1).Date;
            var bookingsForSpecifiedDate = _bookings
                .Where(x => x.DateFrom >= dateFrom && x.DateTo <= dateTo)
                .ToList();
            
            await using var dbContext = new AppDbContext(_options);
            var query = new GetBookingsForDashboardQuery(dbContext);
            var specialistsIds = new List<long> {_user1.Id, _user2.Id, _user3.Id};
            var inputDto = new GetBookingsForDashboardQueryInputDto
            {
                CompanyId = _company.Id,
                DateFrom = dateFrom,
                DateTo = dateTo,
                SpecialistsIds = specialistsIds
            };

            var result = await query.ExecuteAsync(inputDto);
            
            Assert.NotNull(result);
            Assert.Equal(bookingsForSpecifiedDate.Count, result.Count);
        }

        private void SetupData(AppDbContext dbContext)
        {
            _user1 = new User {FirstName = "Vlada", LastName = "Izotova"};
            _user2 = new User {FirstName = "Dan", LastName = "Wang"};
            _user3 = new User {FirstName = "Jari", LastName = "Maenpaa"};

            dbContext.Users.Add(_user1);
            dbContext.Users.Add(_user2);
            dbContext.Users.Add(_user3);

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
                FirstName = "Joe",
                LastName = "Ptacek",
                PhoneNumber = "12345678",
                Email = "joe.ptacek@rockrock.com",
                ClientCategory = ClientCategory.VIP,
                CompanyId = _company.Id
            };
            _client2 = new Client
            {
                FirstName = "Jeremy",
                LastName = "Wagner",
                PhoneNumber = "12345678",
                Email = "jeremy.wagner@bhp.com",
                ClientCategory = ClientCategory.Permanent,
                CompanyId = _company.Id
            };
            _client3 = new Client
            {
                FirstName = "Tony",
                LastName = "Lazaro",
                PhoneNumber = "12345678",
                Email = "tony.lazaro@email.com",
                ClientCategory = ClientCategory.Permanent,
                CompanyId = _company.Id
            };
            _client4 = new Client
            {
                FirstName = "Jeff",
                LastName = "Gruslin",
                PhoneNumber = "12345678",
                Email = "jeff.grsln@vitrem.com",
                ClientCategory = ClientCategory.VIP,
                CompanyId = _company.Id
            };
            _client5 = new Client
            {
                FirstName = "Jack",
                LastName = "Owen",
                PhoneNumber = "12345678",
                Email = "jack.owen@email.com",
                ClientCategory = ClientCategory.Permanent,
                CompanyId = _company.Id
            };
            _client6 = new Client
            {
                FirstName = "Brendan",
                LastName = "Garrett",
                PhoneNumber = "12345678",
                Email = "brendan.garrett@email.com",
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