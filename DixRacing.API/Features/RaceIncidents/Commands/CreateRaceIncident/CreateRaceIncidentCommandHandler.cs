using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.CreateRaceIncident
{
    public class CreateRaceIncidentCommandHandler : IRequestHandler<CreateRaceIncidentCommand, int>
    {
        private readonly IRepository<RaceIncident> _repository;

        public CreateRaceIncidentCommandHandler(IRepository<RaceIncident> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateRaceIncidentCommand request, CancellationToken cancellationToken)
        {
            var raceIncident = new RaceIncident
            {
                Description = request.raceIncidentDto.description,
                RaceId = request.raceIncidentDto.raceId,
                IsSolved=0,
                Lap = request.raceIncidentDto.lap,
                Time = request.raceIncidentDto.time,
                UserId = request.raceIncidentDto.userId,
                ReportedUserId = request.raceIncidentDto.reportedUserId
            };
            return await _repository.CreateAsync(raceIncident);
        }
    }
}