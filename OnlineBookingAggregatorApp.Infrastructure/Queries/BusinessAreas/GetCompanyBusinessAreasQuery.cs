using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.BusinessAreas;
using OnlineBookingAggregatorApp.Persistence.Data;
using OnlineBookingAggregatorApp.Persistence.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Queries.BusinessAreas
{
    public class GetCompanyBusinessAreasQuery : Query<long, IList<CompanyBusinessAreaDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCompanyBusinessAreasQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<CompanyBusinessAreaDto>> ExecuteAsync(long input, CancellationToken cancellationToken = default)
        {
            var company = await _dbContext.Companies
                .AsNoTracking()
                .Include(x => x.CompanyBusinessAreas)
                .FirstByIdOrDefaultAsync(input, cancellationToken);
            
            return company.CompanyBusinessAreas.Select(x => new CompanyBusinessAreaDto
            {
                BusinessAreaId = x.BusinessArea,
                BusinessArea = Enum.GetName(typeof(BusinessArea), x.BusinessArea)
            }).ToList();
        }
    }
}