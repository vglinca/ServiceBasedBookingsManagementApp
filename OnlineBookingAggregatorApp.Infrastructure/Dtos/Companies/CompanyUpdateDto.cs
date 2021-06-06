using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Address;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies
{
    public class CompanyUpdateDto
    {
        public string Name { get; set; }
        public CompanyType CompanyType { get; set; }
        public EmployeesSize EmployeesSize { get; set; }
        public BusinessArea[] BusinessAreas { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
    }
}