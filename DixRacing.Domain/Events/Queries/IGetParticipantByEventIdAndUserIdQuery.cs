using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries;

public interface IGetParticipantByEventIdAndUserIdQuery
{
    public Task<EventParticipantReadModel> ExecuteAsync(int eventId, int userId);
}