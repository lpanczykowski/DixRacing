using MediatR;
using System;

namespace API.Features.Events.Commands.CreateEvent
{
    public record CreateEventCommand(CreateEventDto eventDto): IRequest<int>;
    public record CreateEventDto(string Name,int GameId,byte[] Photo);
}
