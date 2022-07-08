using DixRacing.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.EventParticipants.Queries.Participants
{
    public record GetEventParticipantsByEventIdResponse(IEnumerable<EventParticipantReadModel> EventParticipants);
}