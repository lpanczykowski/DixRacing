using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class EventParticipantsRepository : Repository<EventParticipants>, IEventParticipantsRepository
    {
        private readonly DataContext _dataContext;

        public EventParticipantsRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<EventParticipants> FindEventParticipantsByEventIdAndUserId(int eventId, int userId)
        {
            var eventParticipant = await _dataContext.EventParticipants.Where(x => x.EventId == eventId && x.UserId == userId).FirstOrDefaultAsync();
            return eventParticipant;
        }
    }
}