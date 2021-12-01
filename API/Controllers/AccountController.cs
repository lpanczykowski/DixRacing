using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DixRacing.Core;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        
        public async Task<ActionResult<AccountRegisterResponse>> AccountRegister(AccountRegisterRequest accountRegisterRequest)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);

            using var hmac = new HMACSHA512();
            user.UserName = registerDto.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordSalt = hmac.Key;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender
                
            };
        }

    }
}