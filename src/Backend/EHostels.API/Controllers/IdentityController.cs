using EHostels.API.AppAuthorization;
using EHostels.Application.DTOs;
using EHostels.Application.Identity.Queries;
using EHostels.Application.Services.Interfaces;
using EHostels.Common;
using EHostels.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHostels.API.Controllers
{
    [Route("api/ehostels/[controller]")]
    [ApiController]
    public class IdentityController : BaseApiController
    {
        private readonly IMediator _mediator;
        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
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
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult> Me()
        {
            CommandResult result = new CommandResult();
            var userInfo = UserInfo;
            var profileData = new ProfileData();
            if(userInfo.entityId != null)
            {
                profileData.UserId = userInfo.entityId;
                profileData.FullName = userInfo.fullName;
                profileData.Email = userInfo.email;
                profileData.IsAuthenticated = true;
            }
            result.StatusCode = (int)StatusCodesEnum.Success;
            result.Data = profileData;
            return Ok(result);
        }
    }
}
