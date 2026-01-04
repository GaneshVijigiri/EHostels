using EHostels.Application.DTOs;
using EHostels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUser(UserDTO user);
        Task<List<User>> GetUsers();
    }
}
