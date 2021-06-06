namespace OnlineBookingAggregatorApp.Domain.ValueObjects
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public Address() { }

        public Address(string country, string city, string street)
        {
            Country = country;
            City = city;
            Street = street;
        }

        public static Address From(string country, string city, string street) =>
            IsValid(country, city, street) ? new Address(country, city, street) : null;

        public static bool IsValid(string country, string city, string street) =>
            country != null && city != null && street != null;

        public override string ToString() => $"{Country} {City} {Street}";
    }
}