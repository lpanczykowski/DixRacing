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

        public async Task<RaceResults> FindRaceResultByUserIdAndRaceIdAsync(int userId, int raceId)
        {
            var raceResults= await _dataContext.RaceResults.Where(x=>x.UserId==userId && x.RaceId==raceId).FirstOrDefaultAsync();
            return raceResults;
        }
    }
}