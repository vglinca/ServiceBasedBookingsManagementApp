using System.Threading.Tasks;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Clients;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Clients
{
    public class UpdateClientCommand : Command<(long, ClientCreateUpdateDto)>
    {
        private readonly AppDbContext _dbContext;

        public UpdateClientCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, ClientCreateUpdateDto) input)
        {
            var (clientId, dto) = input;
            var client = await _dbContext.Clients.SingleByIdOrDefaultAsync(clientId);

            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.PhoneNumber = dto.PhoneNumber;
            client.AdditionalPhoneNumber = dto.AdditionalPhoneNumber;
            client.Email = dto.Email;
            client.ClientCategory = dto.ClientCategory;
            client.Gender = dto.Gender;
            client.DateOfBirth = dto.DateOfBirth;
            client.Comments = dto.Comments;
        }
    }
}