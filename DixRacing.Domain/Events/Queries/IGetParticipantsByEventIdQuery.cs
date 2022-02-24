using DixRacing.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events.Queries
{
    public interface IGetParticipantsByEventIdQuery
    {
        Task<PaginatedResult<EventParticipantReadModel>> ExecuteAsync(EventParticipantPaginatedRequest request);
    }
}