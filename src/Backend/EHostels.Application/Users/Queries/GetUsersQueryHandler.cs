using EHostels.Application.Services.Interfaces;
using EHostels.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserService _userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsers().ConfigureAwait(false);
            return result;
        }
    }
}
