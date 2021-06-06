using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum ClientCategory
    {
        Loyal = 1,
        Permanent,
        VIP
    }

    public class ClientCategoryEntity : EnumEntity<ClientCategory>
    {
        public ClientCategoryEntity()
        {
        }

        public ClientCategoryEntity(ClientCategory id, string name) : base(id, name)
        {
        }
    }

    public class ClientCategoryEntityFactory : EnumEntityFactory<ClientCategory, ClientCategoryEntity>
    {
        public static ClientCategoryEntityFactory Instance { get; } = new ClientCategoryEntityFactory();

        public ClientCategoryEntityFactory()
        {
            Register(
                new ClientCategoryEntity(ClientCategory.Loyal, "Loyal"),
                new ClientCategoryEntity(ClientCategory.Permanent, "Permanent"),
                new ClientCategoryEntity(ClientCategory.VIP, "VIP"));
        }
    }
}