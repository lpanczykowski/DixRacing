using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetParticipantsByEventIdQuery
    {
        Task<IEnumerable<EventParticipantReadModel>> ExecuteAsync(int eventId);
    }
}