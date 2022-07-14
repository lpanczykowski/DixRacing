using MediatR;

namespace API.Features.Events.Queries.GetAllEvents
{
    public record GetAllEventsRequest(bool OnlyActiveEvents) : IRequest<GetAllEventsResponse>;
}
