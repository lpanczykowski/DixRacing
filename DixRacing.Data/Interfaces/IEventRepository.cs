using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IEventRepository : IRepository<Events>
    {
        Task<Events> FindEventByIdAsync(int eventId);
        Task<ICollection<Rounds>> FindRacesByEventIdAsync(int eventId);
    }
}