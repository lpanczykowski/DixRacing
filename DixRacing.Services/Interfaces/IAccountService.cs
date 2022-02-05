using DixRacing.Data.Entites;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Users> AttachSteamToAccount(string steamId, int userId);
        Task<bool> CheckIfUserExistsByEmail(string email);
    }
}