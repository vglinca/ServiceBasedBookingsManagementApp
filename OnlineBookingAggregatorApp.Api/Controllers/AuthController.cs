using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingAggregatorApp.Api.Models.Auth;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Enums;

namespace OnlineBookingAggregatorApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : ControllerBase
    {
        private readonly IAppAuthorizationService _authService;
        public AuthController(IAppAuthorizationService authService) => _authService = authService;

        [AllowAnonymous]
        [HttpPost("register-company-chief")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterCompanyChief([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterUserAsync(model, SystemRole.CompanyAdmin);
            return result.Succeeded ? 
                StatusCode(StatusCodes.Status201Created, result.Succeeded) : 
                StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }

        [AllowAnonymous]
        [HttpPost("employee-authorize")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AuthorizeEmployee([FromBody] LoginModel model)
        {
            var (accessToken, refreshToken) = await _authService.SignInAsync(model);
            //HttpContext.Session.SetString("JWToken", token);
            return Ok(new RefreshAccessTokenModel {AccessToken = accessToken, RefreshToken = refreshToken});
        }

        [HttpPost("employee-change-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangeEmployeePassword([FromBody] EmployeeChangePasswordModel model)
        {
            var result = await _authService.ChangePasswordAsync(model);
            return result.Succeeded ? 
                StatusCode(StatusCodes.Status200OK, result.Succeeded) : 
                StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }

        [AllowAnonymous]
        [HttpPost("{userId:long}/refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RefreshAccessToken([FromRoute] long userId, [FromBody] RefreshAccessTokenModel model)
        {
            var (accessToken, refreshToken) = await _authService.RefreshTokenAsync(userId, model.AccessToken, model.RefreshToken);
            return Ok(new RefreshAccessTokenModel {AccessToken = accessToken, RefreshToken = refreshToken});
        }

        [HttpPut("employee-update-profile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmployeeProfile([FromBody] UpdateProfileModel model)
        {
            var result = await _authService.EditUserProfileAsync(model);
            return result.Succeeded ? 
                StatusCode(StatusCodes.Status200OK, result.Succeeded) : 
                StatusCode(StatusCodes.Status400BadRequest, result.Errors);

        }

        [HttpPost("sign-out")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();
            return Ok();
        }
    }
}