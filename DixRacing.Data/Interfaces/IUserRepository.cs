using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> FindUserByEmail(string email);

        Task<Users> GetUserDataById(int userId);
    }
}