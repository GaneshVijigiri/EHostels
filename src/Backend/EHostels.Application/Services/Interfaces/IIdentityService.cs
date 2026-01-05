using EHostels.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> ValidateUser(LoginDTO login);
    }
}
