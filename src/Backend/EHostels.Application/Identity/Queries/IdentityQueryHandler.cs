using EHostels.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Identity.Queries
{
    public class IdentityQueryHandler : IRequestHandler<IdentityQuery, bool>
    {
        private readonly IIdentityService _identityService;
        public IdentityQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<bool> Handle(IdentityQuery request, CancellationToken cancellationToken)
        {
            var result = await _identityService.ValidateUser(request.loginDTO).ConfigureAwait(false);
            return result;
        }
    }
}
