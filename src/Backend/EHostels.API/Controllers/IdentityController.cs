using EHostels.Application.DTOs;
using EHostels.Application.Identity.Queries;
using EHostels.Application.Services.Interfaces;
using EHostels.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHostels.API.Controllers
{
    [Route("api/ehostels/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var result = await _mediator.Send(new IdentityQuery() { loginDTO = login }).ConfigureAwait(false);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody]string token)
        {
            var result = await _mediator.Send(new RefreshTokenQuery() { Token = token }).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
