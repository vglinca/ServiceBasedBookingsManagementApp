using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum BookingState
    {
        WaitingForClient = 1,
        ClientArrived,
        ClientMissing,
        Confirmed,
        Cancelled
    }

    public class BookingStateEntity : EnumEntity<BookingState>
    {
        public string Icon { get; set; }
        public BookingStateEntity() {}

        public BookingStateEntity(BookingState id, string name, string icon) : base(id, name)
        {
            Icon = icon;
        }
    }

    public class BookingStateEntityFactory : EnumEntityFactory<BookingState, BookingStateEntity>
    {
        public static BookingStateEntityFactory Instance { get; } = new BookingStateEntityFactory();

        public BookingStateEntityFactory()
        {
            Register(
                new BookingStateEntity(BookingState.WaitingForClient, "Waiting For Client", "access_time"),
                new BookingStateEntity(BookingState.ClientArrived, "Client Arrived", "hail"),
                new BookingStateEntity(BookingState.ClientMissing, "Client Missing", "person_off"),
                new BookingStateEntity(BookingState.Confirmed, "Client Confirmed", "check"),
                new BookingStateEntity(BookingState.Cancelled, "Cancelled", "clear"));
        }
    }
}