using EHostels.Application.DTOs;
using EHostels.Application.Identity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Identity.Queries
{
    public class IdentityQuery : IRequest<AuthenticateResponse>
    {
        public LoginDTO loginDTO { get; set; } = new LoginDTO();
    }
}
