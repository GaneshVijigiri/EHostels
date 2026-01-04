using EHostels.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Users.Commands
{
    public class AddUserCommandHandler  : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUserService _userService;
        public AddUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.AddUser(request.userDTO).ConfigureAwait(false);
            return result;
        }
    }
}
