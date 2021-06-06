using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Bookings
{
    public class BookingColourDto
    {
        public Colour Id { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string Name { get; set; }

        public static BookingColourDto From(Colour? c)
        {
            var entity = ColourEntityFactory.Instance.GetNullable(c) ?? ColourEntityFactory.Instance.Get(Colour.Grey);

            return new BookingColourDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Primary = entity.Primary,
                Secondary = entity.Secondary
            };
        }
    }
}