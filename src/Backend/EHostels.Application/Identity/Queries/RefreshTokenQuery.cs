using EHostels.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Identity.Queries
{
    public class RefreshTokenQuery : IRequest<CommandResult>
    {
        public string Token { get; set; } = string.Empty;
    }
}
