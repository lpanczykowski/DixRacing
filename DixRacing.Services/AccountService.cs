using System;
using System.Threading.Tasks;
using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DixRacing.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        private readonly IRepository<Users> _userRepository;

        public AccountService(DataContext context,
                              IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<bool> CheckIfUserExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);

        }
        public async Task<Users> AttachSteamToAccount(string steamId, int userId)
        {
            var user = await _userRepository.FindAsync(userId);
            if (user == null) throw new Exception ("User not found");
            user.SteamId = steamId;
            return await _userRepository.UpdateAsync(user);
        }

    }
}