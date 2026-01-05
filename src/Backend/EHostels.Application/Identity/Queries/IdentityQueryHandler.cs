using EHostels.Application.Identity.Models;
using EHostels.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Identity.Queries
{
    public class IdentityQueryHandler : IRequestHandler<IdentityQuery, AuthenticateResponse>
    {
        private readonly IIdentityService _identityService;
        public IdentityQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<AuthenticateResponse> Handle(IdentityQuery request, CancellationToken cancellationToken)
        {
            var result = await _identityService.ValidateUser(request.loginDTO).ConfigureAwait(false);
            return result;
        }
    }
}
