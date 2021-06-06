namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Address
{
    public class AddressDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public static AddressDto From(Domain.ValueObjects.Address src) => new()
        {
            Country = src.Country,
            City = src.City,
            Street = src.Street
        };
    }
}