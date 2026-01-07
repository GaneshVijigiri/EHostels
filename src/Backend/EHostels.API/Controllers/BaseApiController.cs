using EHostels.Common.Enums;
using EHostels.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace EHostels.API.Controllers
{
    [Route("api/ehostels/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public UserData UserInfo
        {
            get
            {
                var identity = User.Identity as ClaimsIdentity;
                var claimsInfo = identity.FindFirst(ConstantMessages.ClaimType)?.Value;
                if(claimsInfo != null)
                {
                    var curUserInfo = JsonSerializer.Deserialize<UserData>(claimsInfo);
                    return curUserInfo;
                }
                return default;
            }
        }
    }
}
