using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.DeleteEvent
{
    public record DeleteEventCommand(DeleteEventDto eventDto) : IRequest<int>;
    public record DeleteEventDto(int Id);
}
