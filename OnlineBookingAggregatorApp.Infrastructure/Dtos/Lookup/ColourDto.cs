using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class ColourDto : BaseLookupDto
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }

        public static ColourDto From(Colour c)
        {
            var entity = ColourEntityFactory.Instance.Get(c);
            return new ColourDto
            {
                Id = (long) entity.Id,
                Name = entity.Name,
                Primary = entity.Primary,
                Secondary = entity.Secondary
            };
        }
    }
}