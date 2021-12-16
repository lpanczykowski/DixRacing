using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IRaceRepository : IRepository<Races>
    {
        Task<Races> FindRaceByIdAsync(int raceId);
        
    }
}