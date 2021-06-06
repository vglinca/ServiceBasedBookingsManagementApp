using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class GenderDto : BaseLookupDto
    {
        public static GenderDto From(Gender gender)
        {
            var genderEntity = GenderEntityFactory.Instance.Get(gender);
            return new GenderDto
            {
                Id = (long) genderEntity.Id,
                Name = genderEntity.Name
            };
        }
    }
}