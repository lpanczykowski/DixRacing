using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.SignForEvent
{
    public class SignForEventCommandHandler : IRequestHandler<SignForEventCommand, int>
    {
        private readonly IRepository<EventParticipant, int> _eventParticipantRepository;

        public SignForEventCommandHandler(IRepository<EventParticipant,int> eventParticipantRepository)
        {
            _eventParticipantRepository = eventParticipantRepository;
        }
    
        public async Task<int> Handle(SignForEventCommand request, CancellationToken cancellationToken)
        {
            var eventParticipant = new EventParticipant()
            {
                EventId = request.eventId,
                UserId = request.userId,
                Car = request.Car,
                Livery = request.Livery,
                Number = request.Number,
                Team = request.Team,                
            };
            return await _eventParticipantRepository.CreateAsync(eventParticipant);
        }
    }
}