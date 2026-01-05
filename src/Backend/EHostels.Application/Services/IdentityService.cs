using EHostels.Application.DTOs;
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
    public class IdentityService : IIdentityService
    {
        private readonly EHostelsContext _context;
        public IdentityService(EHostelsContext context)
        {
            _context = context;
        }
        public async Task<bool> ValidateUser(LoginDTO login)
        {
            if(login != null)
            {
                var isValid = await _context.Users.AnyAsync(u => u.Email == login.Email && u.Password == login.Password).ConfigureAwait(false);
                return isValid;
            }
            return Task.FromResult(false).Result;
        }
    }
}
