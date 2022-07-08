using DixRacing.Domain.Events.Queries;

namespace API.Features.EventParticipants.Queries.GetParticipantByEventId;

public record GetParticipantByEventIdResponse(EventParticipantReadModel EventParticipantReadModel);
