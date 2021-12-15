using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class EventRepository : Repository<Events>, IEventRepository
    {
        private readonly DataContext _dataContext;

        public EventRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Events> FindEventByIdAsync(int eventId)
        {
            var raceEvent = await _dataContext.Events.Where(x=>x.EventId == eventId).FirstOrDefaultAsync();
            return raceEvent;
        }
    }
}