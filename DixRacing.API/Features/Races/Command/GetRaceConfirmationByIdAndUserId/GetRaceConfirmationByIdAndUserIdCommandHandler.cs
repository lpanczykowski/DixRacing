using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Races.Command.GetRaceConfirmationByIdAndUserId
{
    public class GetRaceConfirmationByIdAndUserIdCommandHandler : IRequestHandler<GetRaceConfirmationByIdAndUserIdCommand, bool>
    {
        private readonly IRepository<RaceResult> _raceResultRepository;

        public GetRaceConfirmationByIdAndUserIdCommandHandler(IRepository<RaceResult> raceResultRepository)
        {
            _raceResultRepository = raceResultRepository;
        }
        public async Task<bool> Handle(GetRaceConfirmationByIdAndUserIdCommand request, CancellationToken cancellationToken)
        {
            var raceResult = await _raceResultRepository.GetUniqueByPropertyAsync(x => x.UserId == request.UserId && x.RaceId == request.RaceId);
            if (raceResult is null) return false;
            return raceResult.IsUserConfirmed > 0;

        }
    }
}