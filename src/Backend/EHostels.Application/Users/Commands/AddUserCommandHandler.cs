using EHostels.Application.Services.Interfaces;
using EHostels.Common;
using EHostels.Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Users.Commands
{
    public class AddUserCommandHandler  : IRequestHandler<AddUserCommand, CommandResult>
    {
        private readonly IUserService _userService;
        public AddUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            CommandResult command = new CommandResult();
            var result = await _userService.AddUser(request.userDTO).ConfigureAwait(false);
            if(result > 0)
            {
                command.IsSuccess = true;
                command.StatusCode = (int)StatusCodesEnum.Created;
                command.Message = ConstantMessages.Insert;
            }
            return command;
        }
    }
}
