using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Commands.Categories;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Categories;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Categories;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class CategoriesController : BaseController
    {
        [HttpGet("{companyId:long}/paged")]
        [PolicyAuthorize(Policy.ViewCategories)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<PagedResult<CategoryDto>>> GetPaged([FromRoute] long companyId, [FromQuery] PagedRequest pagedRequest,
            CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCategoriesPagedByCompanyIdQuery, (long, PagedRequest), PagedResult<CategoryDto>>((companyId, pagedRequest), cancellationToken);
        }

        [HttpGet("{companyId:long}/brief")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<CategoryBriefDto>>> GetCategoriesForSidenav([FromRoute] long companyId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCategoriesBriefQuery, long, IList<CategoryBriefDto>>(companyId, cancellationToken);
        }

        [HttpGet("{categoryId:long}")]
        [PolicyAuthorize(Policy.ViewCategories)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<CategoryDto>> GetById([FromRoute] long categoryId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCategoryByIdQuery, long, CategoryDto>(categoryId, cancellationToken);
        }

        [HttpGet("category-unique-name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<bool>> CategoryNameUnique([FromQuery] string name, [FromQuery] long? id, CancellationToken cancellationToken)
        {
            return ExecuteQuery<CheckCategoryNameIsUniqueQuery, (string, long?), bool>((name, id), cancellationToken);
        }

        [HttpGet("{categoryId:long}/contains-service")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<bool>> ContainsServices([FromRoute] long categoryId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<CanDeleteCategoryQuery, long, bool>(categoryId, cancellationToken);
        }

        [HttpPost("{companyId:long}")]
        [PolicyAuthorize(Policy.AddCategories)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult<long>> Create([FromRoute] long companyId, [FromBody] CategoryCreateUpdateDto input)
        {
            return ExecuteCommandReturningEntityId<AddCategoryCommand, (long, CategoryCreateUpdateDto), Category>((companyId, input));
        }

        [HttpPut("{categoryId:long}")]
        [PolicyAuthorize(Policy.EditCategories)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult> Update([FromRoute] long categoryId, [FromBody] CategoryCreateUpdateDto input)
        {
            return ExecuteCommand<UpdateCategoryCommand, (long, CategoryCreateUpdateDto)>((categoryId, input));
        }
        
        [HttpDelete("{categoryId:long}")]
        [PolicyAuthorize(Policy.DeleteCategories)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ActionResult> Delete([FromRoute] long categoryId)
        {
            return ExecuteCommand<DeleteCategoryCommand, long>(categoryId);
        }
    }
}