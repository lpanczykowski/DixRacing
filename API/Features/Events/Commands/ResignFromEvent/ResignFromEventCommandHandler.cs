using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Commands.ResignFromEvent
{
    public class ResignFromEventCommandHandler : IRequestHandler<ResignFromEventCommand, bool>
    {
        private readonly IRepository<EventParticipant> _repository;

        public ResignFromEventCommandHandler(IRepository<EventParticipant> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ResignFromEventCommand request, CancellationToken cancellationToken)
        {
            var participant = await _repository.GetUniqueByPropertyAsync(x => x.EventId == request.eventId && x.UserId == request.userId);
            return _repository.DeleteEntity(participant) > 0;

        }
    }
}