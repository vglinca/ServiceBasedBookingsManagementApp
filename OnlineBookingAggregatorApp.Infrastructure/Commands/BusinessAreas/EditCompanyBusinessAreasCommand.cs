using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Commands.BusinessAreas
{
    public class EditCompanyBusinessAreasCommand : Command<(long, IList<BusinessArea>)>
    {
        private readonly AppDbContext _dbContext;

        public EditCompanyBusinessAreasCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task ExecuteAsync((long, IList<BusinessArea>) input)
        {
            var (companyId, inputBusinessAreas) = input;
            var company = await _dbContext.Companies.FirstByIdAsync(companyId);
            
            var companyBusinessAReas = inputBusinessAreas
                .Select(businessArea => new CompanyBusinessArea(company, businessArea))
                .ToList();

            var companyBusinessAreasToRemove = (await _dbContext.CompanyBusinessAreas
                .Where(x => x.CompanyId == companyId)
                .Select(x => x.BusinessArea)
                .ToListAsync())
                .Except(inputBusinessAreas)
                .Select(x => new CompanyBusinessArea(company, x));
            
            _dbContext.CompanyBusinessAreas.RemoveRange(companyBusinessAreasToRemove);
            await _dbContext.CompanyBusinessAreas.AddRangeAsync(companyBusinessAReas);
        }
    }
}