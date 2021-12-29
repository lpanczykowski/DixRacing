using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class RaceResultsRepository : Repository<RaceResults>, IRaceResultsRepository
    {
        private readonly DataContext _dataContext;

        public RaceResultsRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }



    }
}