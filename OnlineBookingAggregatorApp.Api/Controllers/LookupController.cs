using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Infrastructure.Dtos.Lookup;
using OnlineBookingAggregatorApp.Infrastructure.Queries.Lookup;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "v1", IgnoreApi = false)]
    public class LookupController : BaseController
    {
        [HttpGet("all-lookups")]
        public Task<ActionResult<AllLookupsDto>> GetLookups(CancellationToken cancellationToken) => 
            ExecuteQuery<GetAllLookupsQuery, AllLookupsDto>(cancellationToken);
    }
}