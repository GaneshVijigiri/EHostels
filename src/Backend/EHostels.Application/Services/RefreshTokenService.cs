using EHostels.Application.Identity.Models;
using EHostels.Application.Services.Interfaces;
using EHostels.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly EHostelsDbContext _context;
        private readonly IIdentityService _identityService;
        public RefreshTokenService(EHostelsDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }
        public async Task<RefreshTokenResponse> RefreshToken(string token)
        {
            RefreshTokenResponse refreshToken = new RefreshTokenResponse();
            if(token != "undefined")
            {
                var tokenDetails = await _context.RefreshTokens.Include(x => x.User).Where(x => x.Token == token).FirstOrDefaultAsync().ConfigureAwait(false);
                tokenDetails.IsExpired = tokenDetails.ExpiredAt < DateTime.UtcNow;
                if (!tokenDetails.IsExpired)
                {
                    refreshToken.AccessToken = _identityService.GenerateJwtToken(tokenDetails.User);
                    refreshToken.RefreshToken = _identityService.GenerateRefreshToken(tokenDetails.User);
                }
                else
                {
                    refreshToken.ErrorMessage = "Refresh token expired";
                }
            }
            else
            {
                refreshToken.ErrorMessage = "Refresh token is required";
            }
            
            return refreshToken;
        }
    }
}
