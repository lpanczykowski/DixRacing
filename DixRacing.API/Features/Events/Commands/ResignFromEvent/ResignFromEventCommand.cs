using MediatR;

namespace API.Features.Events.Commands.ResignFromEvent
{
    public record ResignFromEventCommand(int eventId, int userId) : IRequest<bool>;
    
}