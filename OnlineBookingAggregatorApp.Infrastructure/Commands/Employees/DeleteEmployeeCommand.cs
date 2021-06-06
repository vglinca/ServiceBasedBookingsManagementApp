using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Employees
{
    public class DeleteEmployeeCommand : Command<long>
    {
        private readonly UserManager<User> _employees;
        private readonly HttpContext _httpContext;

        public DeleteEmployeeCommand(UserManager<User> employees, IHttpContextAccessor accessor)
        {
            _employees = employees;
            _httpContext = accessor.HttpContext;
        }

        public override async Task ExecuteAsync(long input)
        {
            int.TryParse(_httpContext.User.Claims.FirstOrDefault(x => x.Type == AppConstants.Parameters.UserId)?.Value,
                out var userId);

            if (userId == input)
            {
                throw new InfrastructureInvalidOperationException("Employee can not be self deleted.");
            }
            
            var employee = await _employees.FindByIdAsync(input.ToString());
            if (employee == null)
            {
                throw EntityNotFoundException.OfType<User>();
            }
            
            await _employees.DeleteAsync(employee);
        }
    }
}