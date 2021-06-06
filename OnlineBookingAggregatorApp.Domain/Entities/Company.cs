using System.Collections.Generic;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Domain.ValueObjects;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public CompanyType CompanyType { get; set; }
        public BusinessType BusinessType { get; set; }
        public EmployeesSize EmployeesSize { get; set; }
        public Address Address { get; set; }
        public string LogoPath { get; set; }
        public EmailAddress Email { get; set; }
        public ICollection<CompanyBusinessArea> CompanyBusinessAreas { get; set; } = new List<CompanyBusinessArea>();
        public ICollection<User> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }

        public Company() { }

        public Company(string name, CompanyType companyType, BusinessType businessType, EmployeesSize employeesSize, Address address, EmailAddress email)
        {
            Name = name;
            CompanyType = companyType;
            BusinessType = businessType;
            EmployeesSize = employeesSize;
            Address = address;
            Email = email;
        }
    }
}