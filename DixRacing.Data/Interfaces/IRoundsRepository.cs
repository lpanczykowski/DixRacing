using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IRoundsRepository : IRepository<Rounds>
    {
        Task<Rounds> FindRoundByTrackAndDate(string trackName, DateTime roundDate);
        
    }
}