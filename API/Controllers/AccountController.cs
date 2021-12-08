using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DixRacing.Core;
using DixRacing.Core.Models.Request;
using DixRacing.Core.Models.Response;
using DixRacing.Data;
using DixRacing.Data.Dtos;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IRegisterService _registerService;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context,
                                 IMapper mapper,
                                 IRegisterService registerService,
                                 IUserRepository userRepository,
                                 ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _registerService = registerService;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        [HttpPost("register")]

        public async Task<ActionResult<AccountRegisterResponse>> AccountRegister(AccountRegisterRequest accountRegisterRequest)
        {
            if (await _registerService.CheckIfUserExistsByMail(accountRegisterRequest)) return BadRequest("Email is taken");
            var user = new Users();

            using var hmac = new HMACSHA512();
            user.Name = accountRegisterRequest.Name.ToLower();
            user.Surname = accountRegisterRequest.Surname.ToLower();
            user.Nick = accountRegisterRequest.Nick.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(accountRegisterRequest.Password));
            user.PasswordSalt = hmac.Key;
            user.Email = accountRegisterRequest.Email;
            await _userRepository.AddAsync(user);
            
            return new AccountRegisterResponse
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            };
        }

    }
}