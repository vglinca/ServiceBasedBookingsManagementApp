using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients
{
    public class ClientForSelectDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static ClientForSelectDto From(Client c) => new()
        {
            Id = c.Id,
            FullName = $"{c.FirstName} {c.LastName}",
            Email = c.Email,
            Phone = c.PhoneNumber
        };
    }
}