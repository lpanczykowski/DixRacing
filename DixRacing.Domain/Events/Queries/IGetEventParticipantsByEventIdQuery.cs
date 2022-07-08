using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetEventParticipantsByEventIdQuery
    {
        Task<IEnumerable<EventParticipantReadModel>> ExecuteAsync(int eventId);
    }
}