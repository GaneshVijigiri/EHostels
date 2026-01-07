using EHostels.Application.DTOs;
using EHostels.Application.Identity.Models;
using EHostels.Application.Services.Interfaces;
using EHostels.Common;
using EHostels.Common.Enums;
using EHostels.Data.Context;
using EHostels.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly EHostelsDbContext _context;
        private readonly JwtSettings _jwtSettings;
        public IdentityService(EHostelsDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthenticateResponse> ValidateUser(LoginDTO login)
        {
            AuthenticateResponse response = new AuthenticateResponse();
            if (login != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password).ConfigureAwait(false);
                if (user != null)
                {
                    response.IsAuthenticated = true;
                    response.AccessToken = GenerateJwtToken(user);
                    response.RefreshToken = GenerateRefreshToken(user);
                }
                else
                {
                    response.IsAuthenticated = false;
                    response.ErrorMessage = ConstantMessages.InvalidCreds;
                }
                    return response;
            }
            return response;
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var claims = new[]
            {
                new Claim("id", user.EntityId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("type", "access")
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private string GenerateRefreshToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var claims = new[]
            {
                new Claim("id", user.EntityId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("type", "refresh")
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
