using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Domain.ValueObjects;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Companies
{
    public class CreateCompanyCommand : Command<CompanyCreateDto, Company>
    {
        private readonly HttpContext _httpContext;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public CreateCompanyCommand(IHttpContextAccessor accessor, AppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpContext = accessor.HttpContext;
        }

        public override async Task<Company> ExecuteAsync(CompanyCreateDto input)
        {
            long.TryParse(_httpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(AppConstants.Parameters.UserId))?.Value, out var userId);

            var company = new Company(input.Name, input.CompanyType, input.BusinessType, input.EmployeesSize, 
                new Address(input.Address.Country, input.Address.City, input.Address.Street), EmailAddress.From(input.Email));

            if (input.CompanyType == CompanyType.PhysicalPerson)
            {
                var userEmail = _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                company.Email = EmailAddress.From(userEmail);
            }
            
            var user = await _userManager.FindByIdAsync(userId.ToString());
            
            if (user is null)
            {
                throw new InfrastructureInvalidOperationException("User can not be null");
            }
            company.SetCreatedBy(userId);
            company.SetUpdatedBy(userId);
            await _dbContext.Companies.AddAsync(company);
            
            user.Company = company;
            await _userManager.UpdateAsync(user);

            var cba = new CompanyBusinessArea(company, input.BusinessArea);
            await _dbContext.CompanyBusinessAreas.AddAsync(cba);
            
            return company;
        }
    }
}