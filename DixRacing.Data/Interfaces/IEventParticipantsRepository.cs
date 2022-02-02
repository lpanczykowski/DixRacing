using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IEventParticipantsRepository: IRepository<EventParticipants>
    {
        Task<EventParticipants> FindEventParticipantsByEventIdAndUserId(int eventId, int userId);
        Task<ICollection<EventParticipants>> GetEventParticipantsByEventIdAsync(int eventId);
    }
}