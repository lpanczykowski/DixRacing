using DixRacing.Domain.SharedKernel;
using System;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands.Steam
{
    public interface IAttachSteamToUserService
    {
        Task<bool> ExecuteAsync(int userId,string steamId);
    }
    public class AttachSteamToUserService : IAttachSteamToUserService
    {
        private readonly IRepository<User> _userRepository;

        public AttachSteamToUserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ExecuteAsync(int userId, string steamId)
        {
           var user = await _userRepository.GetByIdAsync(userId);
           if (user is null) throw new InvalidOperationException("User not found");
           user.SteamId = steamId;
           return  _userRepository.Update(user) > 0;
            
        }
    }
}