// using OnlineBookingAggregatorApp.Domain.Enums;
//
// namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
// {
//     public class WeekendTypeDto : BaseLookupDto
//     {
//         public static WeekendTypeDto From(WeekendType weekendType)
//         {
//             var entity = WeekendTypeEntityFactory.Instance.Get(weekendType);
//             return new WeekendTypeDto
//             {
//                 Id = (long) entity.Id,
//                 Name = entity.Name
//             };
//         }
//     }
// }