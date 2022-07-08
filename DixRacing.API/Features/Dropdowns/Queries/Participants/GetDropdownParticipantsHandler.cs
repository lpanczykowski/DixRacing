using API.Features.EventParticipants.Queries.Participants;
using AutoMapper;
using DixRacing.Domain.Events.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Participants
{
    public class GetDropdownParticipantsHandler : IRequestHandler<GetDropdownParticipantsRequest, GetDropdownResponse>
    {
        private readonly IGetEventParticipantsByEventIdQuery _query;
        private readonly IMapper _mapper;

        public GetDropdownParticipantsHandler(IGetEventParticipantsByEventIdQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

           public async Task<GetDropdownResponse> Handle(GetDropdownParticipantsRequest request, CancellationToken cancellationToken)
        {
            var participants= await _query.ExecuteAsync(request.eventId);
            var result= _mapper.Map<IEnumerable<EventParticipantReadModel>,IEnumerable<DropdownDto>>(participants).ToList();
            return new GetDropdownResponse(result);
        }
    }
}
