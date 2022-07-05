using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System.Collections.Generic;

namespace API.Features.EventParticipants.Queries
{
    public record GetParticipantsByEventIdRequest(EventParticipantPaginatedRequest request) : IRequest<PaginatedResult<EventParticipantReadModel>>;
}