using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Services
{
    public class UpdateServiceCommand : Command<(long, ServiceUpdateDto)>
    {
        private readonly AppDbContext _dbContext;

        public UpdateServiceCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, ServiceUpdateDto) input)
        {
            var (serviceId, dto) = input;
            var service = await _dbContext.Services.FirstByIdOrDefaultAsync(serviceId);

            service.Name = dto.Name;
            service.Description = dto.Description;
            service.CategoryId = dto.CategoryId;

            await ProcessServiceSpecialists(serviceId, dto, service);
        }

        private async Task ProcessServiceSpecialists(long serviceId, ServiceUpdateDto dto, Service service)
        {
            var serviceSpecialists = await _dbContext.ServiceEmployees
                .Where(x => x.ServiceId == serviceId)
                .ToListAsync();

            var serviceSpecialistsToRemove = serviceSpecialists
                .Where(x => !dto.EmployeeIds.Contains(x.EmployeeId))
                .ToList();

            var servicesToAddForEmployeeIds = dto.EmployeeIds
                .Where(x => !serviceSpecialists.Select(y => y.EmployeeId).Contains(x))
                .ToList();

            _dbContext.ServiceEmployees.RemoveRange(serviceSpecialistsToRemove);

            var newServiceSpecialists = servicesToAddForEmployeeIds
                .Select(specialistId => new ServiceEmployee
                {
                    ServiceId = service.Id, EmployeeId = specialistId
                })
                .ToList();

            await _dbContext.ServiceEmployees.AddRangeAsync(newServiceSpecialists);
        }
    }
}