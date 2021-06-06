using System.Collections.Generic;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Position : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<User> Employees { get; set; } = new List<User>();

        public Position()
        {
        }

        public Position(string name, string description, long companyId, Company company)
        {
            Name = name;
            Description = description;
            CompanyId = companyId;
            Company = company;
        }
    }
}