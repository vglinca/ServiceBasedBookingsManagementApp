using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Services
{
    public class ServiceDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string Category { get; set; }
        public BusinessArea BusinessArea { get; set; }
        public string LogoPath { get; set; }
        public IList<long> EmployeeIds { get; set; }
        public int BookingsCount { get; set; }

        public static ServiceDto From(Service src) => new()
        {
            Id = src.Id,
            CompanyId = src.Category.CompanyId,
            Name = src.Name,
            Description = src.Description,
            CategoryId = src.CategoryId,
            Category = src.Category.Name,
            BusinessArea = src.Category.BusinessArea,
            LogoPath = src.LogoPath,
            BookingsCount = src.Bookings.Count
        };
    }
}