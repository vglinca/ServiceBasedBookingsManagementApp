using System;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Address;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies
{
    public class CompanyDto
    {
        public long Id { get; set; }
        public CompanyType CompanyTypeId { get; set; }
        public string CompanyType { get; set; }
        public BusinessType BusinessTypeId { get; set; }
        public string BusinessType { get; set; }
        public EmployeesSize EmployeesSize { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string LogoPath { get; set; }

        public static CompanyDto From(Company src) => new()
        {
            Id = src.Id,
            CompanyTypeId = src.CompanyType,
            CompanyType = Enum.GetName(typeof(CompanyType), src.CompanyType),
            BusinessTypeId = src.BusinessType,
            BusinessType = Enum.GetName(typeof(BusinessType), src.BusinessType),
            EmployeesSize = src.EmployeesSize,
            Name = src.Name,
            Email = src.Email.Value,
            Address = AddressDto.From(src.Address),
            LogoPath = src.LogoPath
        };
    }
}