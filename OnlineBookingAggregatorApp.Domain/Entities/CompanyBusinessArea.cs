using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class CompanyBusinessArea : Entity
    {
        public Company Company { get; set; }
        public long CompanyId { get; set; }
        public BusinessArea BusinessArea { get; set; }

        public CompanyBusinessArea()
        {
        }

        public CompanyBusinessArea(Company company, BusinessArea businessArea)
        {
            Company = company;
            BusinessArea = businessArea;
        }
    }
}