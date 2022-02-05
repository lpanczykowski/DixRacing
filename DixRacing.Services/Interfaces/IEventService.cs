using DixRacing.Data.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IEventService
    {
        Task<ICollection<GetEventParticipantsResponse>> GetEventParticipantsResponsesByEventId(int eventId);
        Task<IEnumerable<GetEventsWithActiveRound>> GetEventsWithActiveRound();
    }
}