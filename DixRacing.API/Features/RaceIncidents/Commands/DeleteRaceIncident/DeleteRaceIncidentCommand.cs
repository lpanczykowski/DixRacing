using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.DeleteRaceIncident
{

    public record DeleteRaceIncidentCommand(DeleteRaceIncidentDto deleteRaceIncidentDto) : IRequest<int> { };

    public record DeleteRaceIncidentDto(
                                        int Id
    )
    { };

}