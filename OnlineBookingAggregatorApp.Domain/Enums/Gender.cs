using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum Gender
    {
        Male = 1,
        Female
    }

    public class GenderEntity : EnumEntity<Gender>
    {
        public GenderEntity()
        {
        }

        public GenderEntity(Gender id, string name) : base(id, name)
        {
        }
    }

    public class GenderEntityFactory : EnumEntityFactory<Gender, GenderEntity>
    {
        public static GenderEntityFactory Instance { get; } = new GenderEntityFactory();

        public GenderEntityFactory()
        {
            Register(
                new GenderEntity(Gender.Male, "Male"),
                new GenderEntity(Gender.Female, "Female")
                );
        }
    }
}