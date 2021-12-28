using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Interfaces
{
    public interface IEventParticipantsRepository: IRepository<EventParticipants>
    {
        Task<EventParticipants> FindEventByIdAndUserId(int eventId, int userId);
    }
}