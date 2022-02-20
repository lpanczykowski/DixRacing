using DixRacing.Domain.Events.Queries;
using MediatR;
using System.Collections.Generic;

namespace API.Features.EventParticipants.Queries
{
    public record GetParticipantsByEventIdRequest(int EventId) : IRequest<IEnumerable<EventParticipantReadModel>>;
}