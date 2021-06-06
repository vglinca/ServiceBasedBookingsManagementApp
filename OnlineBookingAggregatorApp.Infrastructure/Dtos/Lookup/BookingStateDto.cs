using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class BookingStateDto : BaseLookupDto
    {
        public string Icon { get; set; }
        public static BookingStateDto From(BookingState state)
        {
            var stateEntity = BookingStateEntityFactory.Instance.Get(state);
            return new BookingStateDto
            {
                Id = (long) stateEntity.Id,
                Name = stateEntity.Name,
                Icon = stateEntity.Icon
            };
        }
    }
}