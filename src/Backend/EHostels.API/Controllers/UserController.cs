using EHostels.Application.DTOs;
using EHostels.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHostels.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Insert")]
        public async Task<ActionResult> Insert(UserDTO user)
        {
            if (user != null)
            {
                int result = await _userService.AddUser(user).ConfigureAwait(false);
                return Ok(result);
            }
            return Ok(0);
        }
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _userService.GetUsers().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
