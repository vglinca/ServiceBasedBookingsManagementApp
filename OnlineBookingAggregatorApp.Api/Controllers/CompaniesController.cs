using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Companies;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.BusinessAreas;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Companies;
using OnlineBookingAggregatorApp.Infrastructure.Queries.BusinessAreas;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Companies;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class CompaniesController : BaseController
    {
        [HttpGet("{companyId:long}")]
        [PolicyAuthorize(Policy.ViewCompanyDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<CompanyDto>> GetCompanyById([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCompanyByIdQuery, long, CompanyDto>(companyId, cancellationToken);
        }

        [HttpGet("{companyId:long}/business-areas")]
        [PolicyAuthorize(Policy.ViewCompanyDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<IList<CompanyBusinessAreaDto>>> GetCompanyBusinessAreas([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCompanyBusinessAreasQuery, long, IList<CompanyBusinessAreaDto>>(companyId, cancellationToken);
        }

        [HttpPost("create-company")]
        [Authorize(Policy = nameof(Policy.EditCompanyDetails))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> CreateCompany([FromBody] CompanyCreateDto input)
        {
            return ExecuteCommandReturningEntityId<CreateCompanyCommand, CompanyCreateDto, Company>(input);
        }

        [HttpPut("{companyId:long}")]
        [PolicyAuthorize(Policy.EditCompanyDetails)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult> UpdateCompany([FromRoute] long companyId, [FromBody] CompanyUpdateDto input)
        {
            return ExecuteCommand<UpdateCompanyCommand, (long, CompanyUpdateDto)>((companyId, input));
        }
    }
}