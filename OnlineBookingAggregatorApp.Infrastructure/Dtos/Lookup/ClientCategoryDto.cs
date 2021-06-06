using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup
{
    public class ClientCategoryDto : BaseLookupDto
    {
        public static ClientCategoryDto From(ClientCategory src)
        {
            var entity = ClientCategoryEntityFactory.Instance.Get(src);
            return new()
            {
                Id = (long) entity.Id,
                Name = entity.Name
            };
        }
    }
}