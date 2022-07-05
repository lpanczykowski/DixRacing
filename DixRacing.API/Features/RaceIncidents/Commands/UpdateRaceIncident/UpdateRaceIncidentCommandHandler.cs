using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.UpdateRaceIncident
{
    public class UpdateRaceIncidentCommandHandler : IRequestHandler<UpdateRaceIncidentCommand, int>
    {
        private readonly IRepository<RaceIncident> _repository;

        public UpdateRaceIncidentCommandHandler(IRepository<RaceIncident> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateRaceIncidentCommand request, CancellationToken cancellationToken)
        {
            var raceIncident= await _repository.GetByIdAsync(request.updateRaceIncidentDto.Id);
            if (raceIncident == null) throw new InvalidOperationException("Entity not found");
            raceIncident.IsSolved=request.updateRaceIncidentDto.IsSolved;
            raceIncident.PointPenalty=request.updateRaceIncidentDto.PointPenalty;
            raceIncident.Penalty=request.updateRaceIncidentDto.Penalty;
            return raceIncident.Id;
        }
    }
}