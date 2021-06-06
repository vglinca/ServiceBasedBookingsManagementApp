// using OnlineBookingAggregatorApp.Domain.Entities;
//
// namespace OnlineBookingAggregatorApp.Domain.Enums
// {
//     public enum DayType
//     {
//         WorkDay = 1,
//         Weekend
//     }
//
//     public class DayTypeEntity : EnumEntity<DayType>
//     {
//         public DayTypeEntity()
//         {
//         }
//
//         public DayTypeEntity(DayType id, string name) : base(id, name)
//         {
//         }
//     }
//
//     public class DayTypeEntityFactory : EnumEntityFactory<DayType, DayTypeEntity>
//     {
//         public static DayTypeEntityFactory Instance { get; } = new DayTypeEntityFactory();
//
//         public DayTypeEntityFactory()
//         {
//             Register(new DayTypeEntity(DayType.WorkDay, "Work Day"),
//                 new DayTypeEntity(DayType.Weekend, "Weekend"));
//         }
//     }
// }