using EHostels.Application.Services.Interfaces;
using EHostels.Common.Enums;
using EHostels.Common.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace EHostels.API.AppAuthorization
{
    public class AddCustomClaims : IClaimsTransformation
    {
        private readonly IUserService _userService;
        public AddCustomClaims(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var clone = principal.Clone();
            if(principal.Identity is ClaimsIdentity newIdentity)
            {
                string email = newIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                if (email == null)
                {
                    return principal;
                }
                var userData = await _userService.GetUserDetailsByEmail(email).ConfigureAwait(false);
                var userInfo = new UserData(userData.EntityId, userData.FullName, userData.Email, userData.MobileNumber ?? string.Empty);
                var userInfoData = JsonSerializer.Serialize(userInfo);
                var userInfoClaim = new Claim("UserData", userInfoData);
                newIdentity.AddClaim(new Claim(ConstantMessages.ClaimType, userInfoData));
            }
            return clone;
        }
    }
}
