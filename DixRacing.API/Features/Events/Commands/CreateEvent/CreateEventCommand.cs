using DixRacing.Domain.Events.Commands.CreateEvent;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Features.Events.Commands.CreateEvent
{
    public record CreateEventCommand(CreateEventDto eventDto): IRequest<int>;
   
}
