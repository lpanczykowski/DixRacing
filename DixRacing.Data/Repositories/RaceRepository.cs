using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class RaceRepository : Repository<Races>, IRaceRepository
    {
        private readonly DataContext _dataContext;

        public RaceRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }        
        public async Task<Races> FindRaceByIdAsync(int raceId)
        {
            var raceEvent = await _dataContext.Races.Where(x=>x.RaceId == raceId).FirstOrDefaultAsync();
            return raceEvent;
        }
        
    }
}