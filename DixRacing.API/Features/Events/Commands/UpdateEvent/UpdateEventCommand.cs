using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.UpdateEvent
{
    public record UpdateEventCommand(UpdateEventDto updateEventDto) : IRequest<int>;
    public record UpdateEventDto(int Id,string Name, int GameId, byte[] Photo);
}
