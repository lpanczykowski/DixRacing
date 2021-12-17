using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class RoundsRepository :  Repository<Rounds>, IRoundsRepository
    {
        private readonly DataContext _dataContext;

        public RoundsRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}