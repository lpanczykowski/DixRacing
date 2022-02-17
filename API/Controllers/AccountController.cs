using API.Features.Users.Commands.LoginUser;
using API.Features.Users.RegisterUser;
using DixRacing.Domain.Users.Commands.Login;
using DixRacing.Domain.Users.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public  Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserCommand command) => 
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
        [HttpGet("connectSteamToUser/{userId}")]
        public async Task<ActionResult<ClaimsPrincipal>> GetClaims(int userId)
        {
            throw new NotImplementedException();
            //var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            //{
            //    claim.Issuer,
            //    claim.OriginalIssuer,
            //    claim.Type,
            //    claim.Value
            //});
            //var steamId = claims.Select(s => s.Value).FirstOrDefault().Split('/').Last();
            //await _accountService.AttachSteamToAccount(steamId, userId);
            //return Redirect("https://localhost:4200");

        }



    }
}