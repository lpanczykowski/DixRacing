using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) :base (dataContext)
        {
            _dataContext = dataContext;
        }
    }
}