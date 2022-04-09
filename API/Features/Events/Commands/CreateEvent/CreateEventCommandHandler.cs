using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.CreateEvent
{ 
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IRepository<Event> _eventRepository;

        public CreateEventCommandHandler(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var _event = new Event(){
                GameId = request.eventDto.GameId,
                Name = request.eventDto.Name,
                Photo = request.eventDto.Photo,                
            };
            return await _eventRepository.CreateAsync(_event);
        }
    }
}
