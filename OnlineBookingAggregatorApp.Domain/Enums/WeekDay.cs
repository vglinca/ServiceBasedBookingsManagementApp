using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum WeekDay
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public class WeekDayEntity : EnumEntity<WeekDay>
    {
        public WeekDayEntity(){}
        public WeekDayEntity(WeekDay id, string name) : base(id, name) { }
    }

    public class WeekDayEntityFactory : EnumEntityFactory<WeekDay, WeekDayEntity>
    {
        public static WeekDayEntityFactory Instance { get; } = new WeekDayEntityFactory();
        public WeekDayEntityFactory()
        {
            Register(
                new WeekDayEntity(WeekDay.Sunday, "Sunday"),
                new WeekDayEntity(WeekDay.Monday, "Monday"),
                new WeekDayEntity(WeekDay.Tuesday, "Tuesday"),
                new WeekDayEntity(WeekDay.Wednesday, "Wednesday"),
                new WeekDayEntity(WeekDay.Thursday, "Thursday"),
                new WeekDayEntity(WeekDay.Friday, "Friday"),
                new WeekDayEntity(WeekDay.Saturday, "Saturday"));
        }
    }
}