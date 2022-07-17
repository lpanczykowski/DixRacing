using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Queries.GetRaceIncidentsByRoundId
{
    public record GetRaceIncidentsByRoundIdRequest(int roundId):IRequest<GetRaceIncidentsByRoundIdResponse>;
}