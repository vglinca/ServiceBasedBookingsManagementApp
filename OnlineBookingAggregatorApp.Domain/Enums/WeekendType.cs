// using OnlineBookingAggregatorApp.Domain.Entities;
//
// namespace OnlineBookingAggregatorApp.Domain.Enums
// {
//     public enum WeekendType
//     {
//         Sick = 1,
//         Leave,
//         PaidHoliday,
//         NonPaidHoliday,
//         PlainWeekend,
//         Absence
//     }
//
//     public class WeekendTypeEntity : EnumEntity<WeekendType>
//     {
//         public WeekendTypeEntity() { }
//         public WeekendTypeEntity(WeekendType id, string name) : base(id, name) { }
//     }
//
//     public class WeekendTypeEntityFactory : EnumEntityFactory<WeekendType, WeekendTypeEntity>
//     {
//         public static WeekendTypeEntityFactory Instance { get; } = new WeekendTypeEntityFactory();
//
//         public WeekendTypeEntityFactory()
//         {
//             Register(
//                 new WeekendTypeEntity(WeekendType.Sick, "Sick"),
//                 new WeekendTypeEntity(WeekendType.Leave, "Leave"),
//                 new WeekendTypeEntity(WeekendType.PaidHoliday, "Paid Holiday"),
//                 new WeekendTypeEntity(WeekendType.NonPaidHoliday, "Unpaid Holiday"),
//                 new WeekendTypeEntity(WeekendType.PlainWeekend, "Standard Weekend (SAT/SUN)"),
//                 new WeekendTypeEntity(WeekendType.Absence, "Absence")
//                 );
//         }
//     }
// }