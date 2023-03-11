using HotelListing.Database;
using HotelListing.Core.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using HotelListing.Core.Models;

namespace HotelListing.Core.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _apiUser;
        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("Lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _apiUser.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_apiUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("HotelListingAPIKey");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(ApiUserLoginDto apiUserLoginDto)
        {
            _apiUser = await _userManager.FindByNameAsync(apiUserLoginDto.Email);
            return (_apiUser != null && await _userManager.CheckPasswordAsync(_apiUser, apiUserLoginDto.Password));
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_apiUser, "HotelListingApi", "RefreshToken");
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_apiUser, "HotelListingApi", "RefreshToken");
            var result = await _userManager.SetAuthenticationTokenAsync(_apiUser, "HotelListingApi", "RefreshToken", newRefreshToken);
            return newRefreshToken;
        }

        public async Task<TokenRequest> VerifyRefreshToken(TokenRequest tokenRequest)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(tokenRequest.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == ClaimTypes.Name)?.Value;
            _apiUser = await _userManager.FindByNameAsync(username);
            var isValid = await _userManager.VerifyUserTokenAsync(_apiUser, "HotelListingApi", "RefreshToken", tokenRequest.RefreshToken);
            if (isValid)
            {
                return new TokenRequest { Token = await CreateToken(), RefreshToken = await CreateRefreshToken() };
            }
            await _userManager.UpdateSecurityStampAsync(_apiUser);
            return null;
        }
    }
}
