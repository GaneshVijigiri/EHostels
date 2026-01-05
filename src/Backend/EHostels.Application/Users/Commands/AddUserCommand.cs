using EHostels.Application.DTOs;
using EHostels.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Users.Commands
{
    public class AddUserCommand : IRequest<CommandResult>
    {
        public UserDTO userDTO { get; set; } = new UserDTO();
    }
}
