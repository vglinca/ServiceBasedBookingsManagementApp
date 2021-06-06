using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.ValueObjects;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.Companies
{
    public class UpdateCompanyCommand : Command<(long, CompanyUpdateDto)>
    {
        private readonly AppDbContext _dbContext;
        

        public UpdateCompanyCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, CompanyUpdateDto) input)
        {
            var (companyId, companyDto) = input;
            var company = await _dbContext.Companies.SingleByIdOrDefaultAsync(companyId);
            company.Name = companyDto.Name;
            company.Email = EmailAddress.From(companyDto.Email);
            company.CompanyType = companyDto.CompanyType;
            company.EmployeesSize = companyDto.EmployeesSize;
            company.Address = new Address(companyDto.Address.Country, companyDto.Address.City, companyDto.Address.Street);
            
            var companyBusinessAreas = await _dbContext.CompanyBusinessAreas
                .AsNoTracking()
                .Where(x => x.CompanyId == company.Id)
                .ToListAsync();
            
            var companyBusinessAreasToAdd = companyDto.BusinessAreas
                .Except(companyBusinessAreas.Select(x => x.BusinessArea))
                .ToList();
            
            var companyBusinessAreasToRemove = companyBusinessAreas
                .Select(x => x.BusinessArea)
                .Except(companyDto.BusinessAreas)
                .ToList();
            
            _dbContext.CompanyBusinessAreas.RemoveRange(companyBusinessAreas.Where(x =>
                companyBusinessAreasToRemove.Contains(x.BusinessArea)));
            
            var newCompanyBusinessAreas = new List<CompanyBusinessArea>();
            
            foreach (var businessArea in companyBusinessAreasToAdd)
            {
                var cba = new CompanyBusinessArea(company, businessArea);
                newCompanyBusinessAreas.Add(cba);
            }

            await _dbContext.CompanyBusinessAreas.AddRangeAsync(newCompanyBusinessAreas);
        }
    }
}