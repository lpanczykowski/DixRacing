using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.UpdateEvent
{
    public record UpdateEventCommand(int Id,string? Name, string? Rules, byte[]? Photo) : IRequest<Unit>;
}
