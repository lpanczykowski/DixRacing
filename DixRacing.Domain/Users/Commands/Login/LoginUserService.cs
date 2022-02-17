using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands.Login
{
    public interface ILoginUserService
    {
        Task<LoginUserResponse> ExecuteAsync(LoginUserDto loginUserDto);
    }
    public class LoginUserService : ILoginUserService
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly ITokenService _tokenService;

        public LoginUserService(IRepository<User, int> userRepository,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<LoginUserResponse> ExecuteAsync(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetUniqeByPropertyAsync(x=>x.Email == loginUserDto.Email);
            if (user == null) throw new InvalidOperationException("Invalid username");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUserDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) throw new InvalidOperationException("Invalid password");
            }
            var response = new LoginUserResponse(user.Email, _tokenService.CreateToken(user.Id.ToString(), user.Email));            
            return response;
        }

    }
}
