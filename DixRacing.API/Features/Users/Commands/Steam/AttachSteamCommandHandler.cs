using DixRacing.Domain.Users.Commands.Steam;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Users.Commands.Steam
{
    public class AttachSteamCommandHandler : IRequestHandler<AttachSteamCommand, bool>
    {
        private readonly IAttachSteamToUserService _service;

        public AttachSteamCommandHandler(IAttachSteamToUserService service)
        {
            _service = service;
        }

        public Task<bool> Handle(AttachSteamCommand request, CancellationToken cancellationToken)
        {
            return _service.ExecuteAsync(request.userId,request.steamId);
        }
    }
}