using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Participants
{
    public record GetDropdownParticipantsRequest(int eventId) : IRequest<GetDropdownResponse>;
}