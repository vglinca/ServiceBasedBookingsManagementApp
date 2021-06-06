using System.Collections.Generic;

namespace OnlineBookingAggregatorApp.Domain.Entities
{
    public class Service : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string LogoPath { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public Service() {}

        public Service(string name, string description, long categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}