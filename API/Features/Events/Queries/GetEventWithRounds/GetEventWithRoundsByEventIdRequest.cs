using MediatR;
using System;

namespace API.Features.Events.Queries.GetEventWithRounds
{
    public record GetEventWithRoundsByEventIdRequest(int Id) :IRequest<GetEventWithRoundsByEventIdResponse>;
}