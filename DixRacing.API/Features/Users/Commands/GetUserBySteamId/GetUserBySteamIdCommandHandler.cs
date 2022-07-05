using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Users.Commands.GetUserBySteamId
{
    public class GetUserBySteamIdCommandHandler : IRequestHandler<GetUserBySteamIdCommand, bool>
    {
        private readonly IRepository<User> _userRepository;

        public GetUserBySteamIdCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(GetUserBySteamIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUniqueByPropertyAsync(x => x.SteamId == request.steamId);
            return user is null;
        }
    }
}