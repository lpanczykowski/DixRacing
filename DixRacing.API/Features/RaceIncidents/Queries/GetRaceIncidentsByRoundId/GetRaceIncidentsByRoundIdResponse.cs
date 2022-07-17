using DixRacing.Domain.Rounds.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Queries.GetRaceIncidentsByRoundId
{
    public record GetRaceIncidentsByRoundIdResponse(ICollection<RoundIncidentsReadModel> roundIncidents)
    {
        
    };
}