// using OnlineBookingAggregatorApp.Domain.Enums;
//
// namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
// {
//     public class DayTypeDto : BaseLookupDto
//     {
//         public static DayTypeDto From(DayType dayType)
//         {
//             var entity = DayTypeEntityFactory.Instance.Get(dayType);
//             return new DayTypeDto
//             {
//                 Id = (long) entity.Id,
//                 Name = entity.Name
//             };
//         }
//     }
// }