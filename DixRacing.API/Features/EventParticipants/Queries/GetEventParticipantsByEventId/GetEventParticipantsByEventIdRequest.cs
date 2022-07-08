using DixRacing.Domain.Events;
using DixRacing.Domain.Races.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.EventParticipants.Queries.Participants
{
    public record GetEventParticipantsByEventIdRequest(int eventId):IRequest<GetEventParticipantsByEventIdResponse>;
}