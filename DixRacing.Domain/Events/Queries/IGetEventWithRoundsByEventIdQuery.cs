using System;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetEventWithRoundsByEventIdQuery
    {
        Task<EventReadModel> ExecuteAsync(int eventId);
    }
}