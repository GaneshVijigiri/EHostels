using EHostels.Application.Services.Interfaces;
using EHostels.Common;
using EHostels.Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Identity.Queries
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, CommandResult>
    {
        private readonly IRefreshTokenService _refreshTokenService;
        public RefreshTokenQueryHandler(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }
        public async Task<CommandResult> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();
            var result = await _refreshTokenService.RefreshToken(request.Token).ConfigureAwait(false);
            if (result.ErrorMessage != null){
                commandResult.IsSuccess = true;
                commandResult.Data = result;
                commandResult.StatusCode = (int)StatusCodesEnum.Success;
            }
            return commandResult;
        }
    }
}
