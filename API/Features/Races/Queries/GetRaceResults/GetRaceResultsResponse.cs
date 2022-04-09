using DixRacing.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Races.Queries.GetRaceResults
{
    public record GetRaceResultsResponse(IEnumerable<UserRaceResultReadModel> UserRaceResults)
    {
        
    }
}