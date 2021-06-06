using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

// ReSharper disable MemberCanBePrivate.Global

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Services
{
    public class DeleteServiceCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteServiceCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync(long input)
        {
            var service = await _dbContext.Services.SingleByIdAsync(input);
            var serviceSpecialists = await _dbContext.ServiceEmployees
                .Where(x => x.ServiceId == input)
                .ToListAsync();
            
            _dbContext.ServiceEmployees.RemoveRange(serviceSpecialists);
            _dbContext.Services.Remove(service);
        }
    }
}