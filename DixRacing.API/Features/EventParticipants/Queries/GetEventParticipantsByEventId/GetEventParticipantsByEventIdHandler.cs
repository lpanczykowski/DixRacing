using AutoMapper;
using DixRacing.Domain.Events;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Races.Services;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.EventParticipants.Queries.Participants
{
    public class GetEventParticipantsByEventIdHandler : IRequestHandler<GetEventParticipantsByEventIdRequest, GetEventParticipantsByEventIdResponse>
    {
        private readonly IGetEventParticipantsByEventIdQuery _query;

        public GetEventParticipantsByEventIdHandler(IGetEventParticipantsByEventIdQuery query)
        {
            _query = query;
        }

           public async Task<GetEventParticipantsByEventIdResponse> Handle(GetEventParticipantsByEventIdRequest request, CancellationToken cancellationToken)
        {
            return new GetEventParticipantsByEventIdResponse (await _query.ExecuteAsync(request.eventId));
        }
}
}