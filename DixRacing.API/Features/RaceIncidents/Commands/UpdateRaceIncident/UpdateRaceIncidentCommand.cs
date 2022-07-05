using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.UpdateRaceIncident
{

    public record UpdateRaceIncidentCommand(UpdateRaceIncidentDto updateRaceIncidentDto) : IRequest<int> { };

    public record UpdateRaceIncidentDto(
                                        int IsSolved,
                                        int PointPenalty,
                                        string Penalty,
                                        int Id
    )
    { };

}