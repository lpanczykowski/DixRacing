using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.CreateRaceIncident
{
    public record CreateRaceIncidentCommand(CreateRaceIncidentDto createRaceIncidentDto) : IRequest<int> { };
    public record CreateRaceIncidentDto(int raceId,
                                        int reportedUserId,
                                        int userId,
                                        string description,
                                        int time,
                                        int lap)
    { };
}