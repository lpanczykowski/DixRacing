using DixRacing.Core.Models.Request;
using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Users> AttachSteamToAccount(string steamId, int userId);
        Task<bool> CheckIfUserExistsByEmail(string email);
    }
}