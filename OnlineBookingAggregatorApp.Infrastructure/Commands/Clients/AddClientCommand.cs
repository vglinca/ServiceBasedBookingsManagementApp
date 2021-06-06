using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Clients
{
    public class AddClientCommand : Command<(long, ClientCreateUpdateDto), Client>
    {
        private readonly AppDbContext _dbContext;

        public AddClientCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Client> ExecuteAsync((long, ClientCreateUpdateDto) input)
        {
            var (companyId, dto) = input;
            
            var client = new Client(dto.FirstName, dto.LastName, dto.PhoneNumber, dto.AdditionalPhoneNumber,
                dto.Email, dto.ClientCategory, dto.Gender, dto.DateOfBirth, dto.Comments, companyId);

            await _dbContext.Clients.AddAsync(client);

            return client;
        }
    }
}