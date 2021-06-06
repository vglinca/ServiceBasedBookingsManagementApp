using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Services
{
    public class ServiceForSelectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static ServiceForSelectDto From(Service s) => new()
        {
            Id = s.Id,
            Name = s.Name
        };
    }
}