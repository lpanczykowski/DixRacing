using API.Features.Users.Commands.GetUserBySteamId;
using API.Features.Users.Commands.LoginUser;
using API.Features.Users.Commands.Steam;
using API.Features.Users.RegisterUser;
using DixRacing.Domain.Users.Commands.Login;
using DixRacing.Domain.Users.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost("register")]
        public Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserCommand command) =>
            SendAsync(command);

        //if (await _accountService.CheckIfUserExistsByEmail(accountRegisterRequest.Email)) return BadRequest("Email is taken");//var user = new Users();//using var hmac = new HMACSHA512();//user.Name = accountRegisterRequest.Name.ToLower();//user.Surname = accountRegisterRequest.Surname.ToLower();//user.Nick = accountRegisterRequest.Nick.ToLower();//user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(accountRegisterRequest.Password));//user.PasswordSalt = hmac.Key;//user.Email = accountRegisterRequest.Email;//user.SteamId = accountRegisterRequest.SteamId;//await _userRepository.AddAsync(user);//return new AccountRegisterResponse//{//    Email = user.Email,//    Token = _tokenService.CreateToken(user),//};
        [HttpPost("login")]
        public Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] LoginUserCommand command) =>
            SendAsync(command);

        [HttpPost("attachDiscord")]
        public async Task<IActionResult> AttachDiscordId()
        {
            throw new NotImplementedException();

        }
        [HttpGet("attachSteamToUser")]
        public async Task<ActionResult> GetClaims()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            var steamId = claims.Select(s => s.Value).FirstOrDefault().Split('/').Last();
            var user = await SendAsync(new GetUserBySteamIdCommand(steamId));
            await SendAsync(new LoginUserCommand(steamId));
            if (user is not null)
                return Redirect("http://localhost:4200");
            return Redirect("http://localhost:4200/profile");
        }
    }
}