using AutoMapper;
using EHostels.Application.DTOs;
using EHostels.Application.Services.Interfaces;
using EHostels.Application.Users.Commands;
using EHostels.Application.Users.Queries;
using EHostels.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHostels.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Insert")]
        public async Task<ActionResult> Insert(UserDTO user)
        {
            if (user != null)
            {
                CommandResult result = await _mediator.Send(new AddUserCommand() { userDTO = user}).ConfigureAwait(false);
                return Ok(result);
            }
            return Ok(0);
        }
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            CommandResult result = await _mediator.Send(new GetUsersQuery() { }).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
