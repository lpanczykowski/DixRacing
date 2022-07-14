using DixRacing.Domain.Events;
using DixRacing.Domain.Events.Commands;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly IUpdateEventService _service;

        public UpdateEventCommandHandler(IUpdateEventService service)
        {
            _service = service;
        }
       
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateEventAsync(new EventDto(request.Id,
                request.Name,
                request.Rules,
                request.Photo));
            return new Unit();
        }
    }
}
