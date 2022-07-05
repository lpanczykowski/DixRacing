
using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Races.Command.RaceConfirmationByIdAndUserId
{
    public class RaceConfirmationByIdAndUserIdCommandHandler : IRequestHandler<RaceConfirmationByIdAndUserIdCommand, bool>
    {
        private readonly IRepository<RaceResult> _raceResultRepository;

        public RaceConfirmationByIdAndUserIdCommandHandler(IRepository<RaceResult> raceResultRepository)
        {
            _raceResultRepository = raceResultRepository;
        }
        public async Task<bool> Handle(RaceConfirmationByIdAndUserIdCommand request, CancellationToken cancellationToken)
        {
            var raceResult = await _raceResultRepository.GetUniqueByPropertyAsync(x => x.RaceId == request.RaceId && x.UserId == request.UserId);
            if (raceResult is not null)
            {
                raceResult.IsUserConfirmed = raceResult.IsUserConfirmed > 0 ? 0 : 1;
                _raceResultRepository.Update(raceResult);
                return raceResult.IsUserConfirmed > 0;
            }
            else
            {
                var newRaceResult = new RaceResult
                {
                    RaceId = request.RaceId,
                    UserId = request.UserId,
                    IsUserConfirmed = 1,
                };
                return true;
            }


        }
    }
}