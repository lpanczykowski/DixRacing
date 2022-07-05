using DixRacing.Domain.Events;
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
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, int>
    {
        private readonly IRepository<Event> _eventRepository;

        public UpdateEventCommandHandler(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
       
        public async Task<int> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _eventRepository.GetByIdAsync(request.updateEventDto.Id);
            if (_event == null) throw new InvalidOperationException("Entity not found");
            _event.Photo = request.updateEventDto.Photo;
            _event.Name = request.updateEventDto.Name;
            _event.GameId = request.updateEventDto.GameId;
            return _event.Id; //TODO
        }
    }
}
