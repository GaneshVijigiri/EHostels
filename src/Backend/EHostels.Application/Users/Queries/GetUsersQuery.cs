using EHostels.Common;
using EHostels.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHostels.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<CommandResult>
    {
    }
}
