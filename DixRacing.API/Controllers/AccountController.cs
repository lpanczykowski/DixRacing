using API.Extensions;
using API.Features.Users.Commands.GetUserBySteamId;
using API.Features.Users.Commands.LoginUser;
using API.Features.Users.Commands.Steam;
using API.Features.Users.RegisterUser;
using DixRacing.Domain.Users.Commands.Login;
using DixRacing.Domain.Users.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class AccountController : BaseApiController
    {
        private readonly ILoginUserService _loginUserService;

        public AccountController(IMediator mediator,ILoginUserService loginUserService) : base(mediator)
        {
            _loginUserService = loginUserService;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("credentials")]
        public async Task<IActionResult> GetCredentials()
        {
            return Ok(User.IsAdmin());

        }
        [HttpGet("attachSteamToUser")]
        public async Task<IActionResult> GetClaims()
        {
            AuthenticateResult result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claim = result.Principal?.Identities.FirstOrDefault()?.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            if (claim == null)
            {
                return Redirect("/home");
            }
            string steamId = claim.Select(s => s.Value).FirstOrDefault()?.Split('/').Last();
            await SendAsync(new GetUserBySteamIdCommand(steamId));
            var token = await _loginUserService.ExecuteAsync(new LoginUserDto(steamId));
            return Redirect($"/profile/{steamId}?token={token.Token}");
        }
    }
}