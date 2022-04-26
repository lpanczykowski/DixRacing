using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.DeleteRaceIncident
{
    public class DeleteRaceIncidentCommandHandler : IRequestHandler<DeleteRaceIncidentCommand, int>
    {
        private readonly IRepository<RaceIncident> _repository;

        public DeleteRaceIncidentCommandHandler(IRepository<RaceIncident> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteRaceIncidentCommand request, CancellationToken cancellationToken)
        {
            var raceIncident = await _repository.GetByIdAsync(request.deleteRaceIncidentDto.Id);
            return  _repository.DeleteEntity(raceIncident);
        }
    }
}