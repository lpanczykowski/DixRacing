using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Commands.CreateRaceIncident
{
    public record CreateRaceIncidentCommand(RaceIncidentDto raceIncidentDto) : IRequest<int> { };
    public record RaceIncidentDto(int raceId,
                                        int reportedUserId,
                                        int userId,
                                        int isSolved,
                                        string description,
                                        int time,
                                        int lap)
    { };
}