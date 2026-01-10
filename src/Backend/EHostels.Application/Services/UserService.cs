using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly EHostelsDbContext _context;
        private readonly IMapper _mapper;
        public UserService(EHostelsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddUser(UserDTO user)
        {
            var newUser = _mapper.Map<User>(user);

            await _context.Users.AddAsync(newUser).ConfigureAwait(false);
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync().ConfigureAwait(false);
        }
        public async Task<User> GetUserDetailsByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new User();
            }

            var user = await _context.Users.Where(x => x.Email == email).Select(x => new User
            {
                EntityId = x.EntityId,
                FullName = x.FullName,
                Email = x.Email,
                MobileNumber = x.MobileNumber
            }).FirstOrDefaultAsync().ConfigureAwait(false);
            return user ?? new User();
        }
    }
}
