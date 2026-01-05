using EHostels.Application.DTOs;
using EHostels.Application.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticateResponse> ValidateUser(LoginDTO login);
    }
}
