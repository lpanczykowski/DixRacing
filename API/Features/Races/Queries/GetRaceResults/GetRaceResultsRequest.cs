using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Races.Queries.GetRaceResults
{
    public record GetRaceResultsRequest(int RaceId,string SessionType) :  IRequest<GetRaceResultsResponse>
    {
        
    }
}