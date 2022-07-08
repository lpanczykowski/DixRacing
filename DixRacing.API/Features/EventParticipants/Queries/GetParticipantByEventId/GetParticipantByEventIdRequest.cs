using DixRacing.Domain.Events.Queries;
using MediatR;

namespace API.Features.EventParticipants.Queries.GetParticipantByEventId;

public record  GetParticipantByEventIdRequest(int eventId,int userId) : IRequest<GetParticipantByEventIdResponse>
{
    
}