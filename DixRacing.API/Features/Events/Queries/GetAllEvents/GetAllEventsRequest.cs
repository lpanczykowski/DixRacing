using MediatR;

namespace API.Features.Events.Queries.GetAllEvents
{
    public record GetAllEventsRequest : IRequest<GetAllEventsResponse>;
}
