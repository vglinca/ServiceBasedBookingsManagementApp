using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.Positions
{
    public class PositionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }

        public static PositionDto From(Position src) => new()
        {
            Id = src.Id,
            Name = src.Name,
            Description = src.Description,
            CompanyId = src.CompanyId
        };
    }
}