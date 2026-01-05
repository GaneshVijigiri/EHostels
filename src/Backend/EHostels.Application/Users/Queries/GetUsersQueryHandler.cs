using EHostels.Application.Services.Interfaces;
using EHostels.Common;
using EHostels.Common.Enums;
using EHostels.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, CommandResult>
    {
        private readonly IUserService _userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommandResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();
            var result = await _userService.GetUsers().ConfigureAwait(false);
            if(result.Count > 0)
            {
                commandResult.StatusCode = (int)StatusCodesEnum.Success;
                commandResult.IsSuccess = true;
                commandResult.Data = result;
            }
            commandResult.Data = result;
            return commandResult;
        }
    }
}
