using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Users.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands
{
    public interface IRegisterUserService
    {
        Task<RegisterUserResponse> ExecuteAsync(RegisterUserDto registerUserDto);
    }
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly ITokenService _tokenService;

        public RegisterUserService(IRepository<User,int> userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<RegisterUserResponse> ExecuteAsync(RegisterUserDto registerUserDto)
        {
            if (await _userRepository.GetUniqueByPropertyAsync(x=>x.Email == registerUserDto.Email) != null) throw new InvalidOperationException("Email is taken");
            var user = new User();
            using var hmac = new HMACSHA512();
            user.Name = registerUserDto.Name.ToLower();
            user.Surname = registerUserDto.Surname.ToLower();
            user.Nick = registerUserDto.Nick.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserDto.Password));
            user.PasswordSalt = hmac.Key;
            user.Email = registerUserDto.Email;
            user.SteamId = registerUserDto.SteamId;
            await _userRepository.CreateAsync(user);
            return new RegisterUserResponse(user.Email, _tokenService.CreateToken(user.Id.ToString(), user.Email));
        }
    }
}
