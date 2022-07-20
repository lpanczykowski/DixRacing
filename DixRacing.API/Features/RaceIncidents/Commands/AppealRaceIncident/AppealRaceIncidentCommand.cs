using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.AppealRaceIncident
{
    public record AppealRaceIncidentCommand(RaceIncidentAppealDto raceIncidentAppealDto):IRequest<int>{};
    
    public record RaceIncidentAppealDto(int Id, string AppealDescription)
    {
    };
}
