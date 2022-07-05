using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
    {
        private readonly IRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IRepository<Event> eventRepository)        {
            _eventRepository = eventRepository;
        }
        public async Task<int> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            return await _eventRepository.DeleteAsync(request.eventDto.Id);
        }
    }
}
