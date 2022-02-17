using API.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class SteamController : BaseApiController

    {
        public SteamController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("login/{userId}")]
        public async Task<ActionResult<bool>> AttachSteamId(int userId)
        {
            if (!await HttpContext.IsProviderSupportedAsync("Steam"))
            {
                return BadRequest();
            }

            return Challenge(new AuthenticationProperties { RedirectUri = $"https://localhost:5001/api/account/connectSteamToUser/{userId}" }, "Steam");
        }
    }
}