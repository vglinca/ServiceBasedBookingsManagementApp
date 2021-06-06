using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions
{
    public class PositionCreateUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static Position To(PositionCreateUpdateDto src) => new()
        {
            Name = src.Name,
            Description = src.Description
        };
    }
}