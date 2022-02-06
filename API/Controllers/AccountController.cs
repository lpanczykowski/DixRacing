using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DixRacing.Core;
using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Data.Models.Request;
using DixRacing.Data.Models.Response;
using DixRacing.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountController(IMapper mapper,
                                 IAccountService accountService,
                                 IUserRepository userRepository,
                                 ITokenService tokenService)
        {
            _mapper = mapper;
            _accountService = accountService;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        [HttpPost("register")]

        public async Task<ActionResult<AccountRegisterResponse>> AccountRegister(AccountRegisterRequest accountRegisterRequest)
        {
            if (await _accountService.CheckIfUserExistsByEmail(accountRegisterRequest.Email)) return BadRequest("Email is taken");
            var user = new Users();

            using var hmac = new HMACSHA512();
            user.Name = accountRegisterRequest.Name.ToLower();
            user.Surname = accountRegisterRequest.Surname.ToLower();
            user.Nick = accountRegisterRequest.Nick.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(accountRegisterRequest.Password));
            user.PasswordSalt = hmac.Key;
            user.Email = accountRegisterRequest.Email;
            user.SteamId = accountRegisterRequest.SteamId;
            await _userRepository.AddAsync(user);

            return new AccountRegisterResponse
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var user = await _userRepository.FindUserByEmail(loginRequest.Email);
            if (user == null) return Unauthorized("Invalid username");
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");

            }
            var response = new LoginResponse
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)

            };
            return Ok(response);
        }      
        [HttpPost("attachDiscord")]
        public async Task<ActionResult<Users>> AttachDiscordId(AttachDiscordRequest attachDiscordRequest)
        {
            var user = await _userRepository.FindAsync(attachDiscordRequest.UserId);
            user.DiscordId = attachDiscordRequest.DiscordId;
            return Ok(await _userRepository.UpdateAsync(user));

        }
        [HttpGet("connectSteamToUser/{userId}")]
        public async Task<ActionResult<ClaimsPrincipal>> GetClaims(int userId)
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            var steamId = claims.Select(s=>s.Value).FirstOrDefault().Split('/').Last();
            await _accountService.AttachSteamToAccount(steamId,userId);
            return Redirect("https://localhost:4200");

        }
       


    }
}