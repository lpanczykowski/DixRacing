using DixRacing.Domain.SharedKernel;
using System;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Commands.Steam
{
    public interface IAttachSteamToUserService
    {
        Task<bool> ExecuteAsync(int userId,string steamId);
    }
    public class AttachSteamToUserService
    {
        private readonly IRepository<User, int> _userRepository;

        public AttachSteamToUserService(IRepository<User,int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ExecuteAsync(int userId, string steamId)
        {
           var user = await _userRepository.GetByIdAsync(userId);
           if (user is null) throw new InvalidOperationException("User not found");
           user.SteamId = steamId;
           return await _userRepository.Update(user) > 0;
            
        }
    }
}