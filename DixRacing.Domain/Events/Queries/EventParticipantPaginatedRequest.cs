using DixRacing.Domain.SharedKernel;

namespace DixRacing.Domain.Events.Queries
{
    public class EventParticipantPaginatedRequest : PaginationRequest
    {
        public int EventId { get; set; }
    }
}