using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.UpdateRaceIncident
{

    public record UpdateRaceIncidentCommand(RaceIncidentSolveDto raceIncidentSolveDto) : IRequest<int> { };

    public record RaceIncidentSolveDto(
                                        int IsSolved,
                                        int PointPenalty,
                                        string Penalty,
                                        int Id
    )
    { };

}