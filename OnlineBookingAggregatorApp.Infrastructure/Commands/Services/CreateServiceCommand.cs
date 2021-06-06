using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Services;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

// ReSharper disable MemberCanBePrivate.Global

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Services
{
    public class CreateServiceCommand : Command<(long, ServiceCreateDto), Service>
    {
        private readonly AppDbContext _dbContext;

        public CreateServiceCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Service> ExecuteAsync((long, ServiceCreateDto) input)
        {
            var (companyId, dto) = input;

            await _dbContext.Companies.AssertEntityExistsAsync(companyId);

            var service = new Service(dto.Name, dto.Description, dto.CategoryId);
            await _dbContext.Services.AddAsync(service);

            var serviceEmployees = new List<ServiceEmployee>();
            foreach (var employeeId in dto.EmployeeIds)
            {
                var serviceEmployee = new ServiceEmployee {Service = service, EmployeeId = employeeId};
                serviceEmployees.Add(serviceEmployee);
            }

            await _dbContext.ServiceEmployees.AddRangeAsync(serviceEmployees);
            return service;
        }
    }
}