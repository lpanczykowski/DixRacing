using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IRaceResultsRepository : IRepository<RaceResults>
    {
       Task<RaceResults> FindRaceResultByUserIdAndRaceIdAsync(int userId,int raceId);
    }
}