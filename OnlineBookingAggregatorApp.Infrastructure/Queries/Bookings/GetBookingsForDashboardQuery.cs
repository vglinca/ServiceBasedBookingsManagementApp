using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.Bookings
{
    public class GetBookingsForDashboardQuery : Query<GetBookingsForDashboardQueryInputDto, IList<BookingDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetBookingsForDashboardQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<BookingDto>> ExecuteAsync(GetBookingsForDashboardQueryInputDto input, CancellationToken cancellationToken = default)
        {
            var dateFrom = input.DateFrom;
            var dateTo = input.DateTo;
            if (input.QueriedForOneDay)
            {
                dateTo = dateFrom.AddTicks(-1).AddDays(1);
            }
            await _dbContext.Companies.AssertEntityExistsAsync(input.CompanyId);

            var bookings = await _dbContext.Users
                .AsNoTracking()
                .Where(x => input.SpecialistsIds.Contains(x.Id))
                .SelectMany(x => x.Bookings
                    .Where(y => y.DateFrom >= dateFrom && y.DateTo <= dateTo))
                .Select(x => new BookingDto
                {
                    Id = x.Id,
                    ClientId = x.ClientId,
                    FirstName = x.Client.FirstName,
                    LastName = x.Client.LastName,
                    Phone = x.Client.PhoneNumber,
                    AdditionalPhone = x.Client.AdditionalPhoneNumber,
                    Email = x.Client.Email,
                    ClientCategory = x.Client.ClientCategory,
                    ClientBirthDate = x.Client.DateOfBirth,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    ServiceId = x.ServiceId,
                    SpecialistId = x.SpecialistId,
                    Comments = x.Comments,
                    Colour = BookingColourDto.From(x.Colour),
                    Specialist = $"{x.Specialist.FirstName} {x.Specialist.LastName}",
                    State = x.State
                })
                .ToListAsync(cancellationToken);

            return bookings;
        }
    }

    public class GetBookingsForDashboardQueryInputDto
    {
        public long CompanyId { get; set; }
        public IList<long> SpecialistsIds { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool QueriedForOneDay { get; set; }
    }
}