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
        Task<LoginUserResponse>  ExecuteAsync(LoginUserDto loginUserDto);
    }
    public class LoginUserService : ILoginUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenService _tokenService;

        public LoginUserService(IRepository<User> userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<LoginUserResponse> ExecuteAsync(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetUniqueByPropertyAsync(x => x.SteamId == loginUserDto.steamId);
            if (user is null)
            {
                new User()
                {
                    SteamId = loginUserDto.steamId
                };
                await _userRepository.CreateAsync(user);
            }
            var response = new LoginUserResponse(user.SteamId, _tokenService.CreateToken(user.Id.ToString(), user.SteamId), user.Id);
            return response;
        }

    }
}
