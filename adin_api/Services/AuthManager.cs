using adin_api.Data.Models;
using adin_api.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace adin_api.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
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
            var jwtSettings = _configuration.GetSection("Jwt");

            var exp = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("validIssuer").Value,
                claims: claims,
                expires: exp,
                signingCredentials: signingCredentials
                );

            return token;
        }

        public Double ExpiresIn()
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            return Convert.ToDouble(jwtSettings.GetSection("lifetime").Value);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,_user.UserName)
            };

            claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id));

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            //var key = Environment.GetEnvironmentVariable("KEY");
            var key = _configuration.GetSection("Jwt").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(UserLoginDTO userDTO)
        {
            _user = await _userManager.FindByNameAsync(userDTO.Email);
            if (_user == null) return false;
            var locked = _user.LockoutEnabled;
            if (locked == true) return false;
            return  await _userManager.CheckPasswordAsync(_user, userDTO.Password);
        }

        public async Task<IList<string>> GetRoles()
        {
            return await _userManager.GetRolesAsync(_user);
        }

        
    }
}
