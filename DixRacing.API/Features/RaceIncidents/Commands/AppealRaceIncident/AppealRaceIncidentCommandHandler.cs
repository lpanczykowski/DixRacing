using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.AppealRaceIncident
{
    public class AppealRaceIncidentCommandHandler : IRequestHandler<AppealRaceIncidentCommand, int>
    {
        private readonly IRepository<RaceIncident> _raceIncidentRepository;

        public AppealRaceIncidentCommandHandler(IRepository<RaceIncident> _raceIncidentRepository)
        {
            this._raceIncidentRepository = _raceIncidentRepository;
        }

        public async Task<int> Handle(AppealRaceIncidentCommand request, CancellationToken cancellationToken)
        {
            var raceIncident= await _raceIncidentRepository.GetByIdAsync(request.raceIncidentAppealDto.Id);
            if (raceIncident == null) throw new InvalidOperationException("Entity not found");
            raceIncident.IsSolved=0;
            raceIncident.AppealDescription=request.raceIncidentAppealDto.AppealDescription;
            return raceIncident.Id;
        }
    }
}