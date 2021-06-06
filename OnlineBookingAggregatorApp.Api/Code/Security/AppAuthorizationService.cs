using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineBookingAggregatorApp.Api.Models.Auth;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Infrastructure.Utils;

namespace OnlineBookingAggregatorApp.Api.Security
{
    public interface IAppAuthorizationService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterModel model, SystemRole role);
        Task<IdentityResult> EditUserProfileAsync(UpdateProfileModel model);
        Task<(string, string)> SignInAsync(LoginModel model);
        Task<(string, string)> RefreshTokenAsync(long userId, string accessToken, string refreshToken);
        Task<IdentityResult> ChangePasswordAsync(EmployeeChangePasswordModel model);
        Task SignOutAsync();
    }
    
    public class AppAppAuthorizationService : IAppAuthorizationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;
        private readonly JwtService _jwtService;

        public AppAppAuthorizationService(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IEmailService emailService, 
            JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterModel model, SystemRole role)
        {
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Gender = model.Gender
            };
            user.UserName = RandomStringGenerator.GenerateRandomString(6);
            user.AssociateWithRole(role);
            var password = RandomStringGenerator.GenerateRandomString(10);
            var result = await _userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                var emailContent = $@"<p>Please use this as you account password. Change it after your first Login.</p>
                                    <br/><span>{password}</span>";
                await _emailService.SendEmailAsync(user.Email, "Account Password", emailContent);
            }

            return result;
        }

        public async Task<IdentityResult> EditUserProfileAsync(UpdateProfileModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new UnauthorizedException(AppConstants.TextMessages.WrongCredentialsMessage);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.Phone;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<(string, string)> SignInAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new UnauthorizedException(AppConstants.TextMessages.WrongCredentialsMessage);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                throw new UnauthorizedException(AppConstants.TextMessages.WrongCredentialsMessage);
            }

            var jwtToken = await _jwtService.CreateAccessTokenAsync(user);
            var refreshToken = JwtService.CreateRefreshToken();

            user.RefreshToken = refreshToken;
            await _userManager.UpdateAsync(user);

            return (jwtToken, refreshToken);
        }

        public async Task<(string, string)> RefreshTokenAsync(long userId, string accessToken, string refreshToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null || user.RefreshToken != refreshToken)
            {
                throw new BadRequestException();
            }

            var newAccessToken = await _jwtService.CreateAccessTokenAsync(user);
            var newRefreshToken = JwtService.CreateRefreshToken();

            user.RefreshToken = null;
            user.RefreshToken = newRefreshToken;

            await _userManager.UpdateAsync(user);

            return (newAccessToken, newRefreshToken);
        }

        public async Task<IdentityResult> ChangePasswordAsync(EmployeeChangePasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new UnauthorizedException(AppConstants.TextMessages.WrongCredentialsMessage);
            }

            return await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();
    }
}