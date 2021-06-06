using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Api.Security
{
    public class JwtService
    {
        private readonly AuthOptions _authOptions;
        private readonly AppDbContext _dbContext;

        public JwtService(IOptions<AuthOptions> options, AppDbContext dbContext)
        {
            _authOptions = options.Value;
            _dbContext = dbContext;
        }

        public async Task<string> CreateAccessTokenAsync(User user)
        {
            var userPolicies = (await _dbContext.PolicyRoles
                    .AsNoTracking()
                    .Where(x => x.Role == user.SystemRole)
                    .OrderBy(x => x.Policy)
                    .Select(x => (long) x.Policy)
                    .ToListAsync())
                .Aggregate(new StringBuilder(string.Empty), 
                    (sb, p) => sb.ToString().Equals(string.Empty) ? sb.Append(p) : sb.Append($",{p}"));
            var company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == user.CompanyId);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, user.SystemRole.ToString()),
                new(AppConstants.Parameters.UserId, user.Id.ToString()),
                new(AppConstants.Parameters.FirstName, user.FirstName),
                new(AppConstants.Parameters.LastName, user.LastName),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(AppConstants.Parameters.CompanyId, company?.Id.ToString() ?? string.Empty),
                new(AppConstants.Parameters.UserPolicies, userPolicies.ToString()),
                new(AppConstants.Parameters.DateOfBirth, user.BirthDate.ToString())
            };

            var credentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                _authOptions.Issuer,
                _authOptions.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddHours(_authOptions.TokenLifetime),
                credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(jwt);
        }

        public static string CreateRefreshToken()
        {
            var num = new byte[64];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(num);
            return Convert.ToBase64String(num);
        }

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = _authOptions.GetSymmetricSecurityKey()
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var claimsPrincipal = tokenHandler.ValidateToken(accessToken, tokenValidationParams, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException(AppConstants.TextMessages.InvalidAccessToken);
            }

            return claimsPrincipal;
        }
    }
}