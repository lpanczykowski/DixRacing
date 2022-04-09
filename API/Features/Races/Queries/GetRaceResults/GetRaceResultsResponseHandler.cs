using DixRacing.Domain.Races.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Races.Queries.GetRaceResults
{
    public class GetRaceResultsResponseHandler : IRequestHandler<GetRaceResultsRequest, GetRaceResultsResponse>
    {
        private readonly IGetRaceResultsQuery _query;

        public GetRaceResultsResponseHandler(IGetRaceResultsQuery query)
        {
            _query = query;
        }
        public async Task<GetRaceResultsResponse> Handle(GetRaceResultsRequest request, CancellationToken cancellationToken)
        {
            var result = await _query.ExecuteAsync(request.RaceId,request.SessionType);
            return new GetRaceResultsResponse(result);
        }
    }
}