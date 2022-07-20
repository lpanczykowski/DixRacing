using DixRacing.Domain.Rounds.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.RaceIncidents.Queries.GetRaceIncidentsByRoundId
{
    public class GetRaceIncidentsByRoundIdHandler : IRequestHandler<GetRaceIncidentsByRoundIdRequest, GetRaceIncidentsByRoundIdResponse>
    {
        private readonly IGetRaceIncidentsByRoundIdQuery _query;

        public GetRaceIncidentsByRoundIdHandler(IGetRaceIncidentsByRoundIdQuery query)
        {
            _query = query;
        }

        public async Task<GetRaceIncidentsByRoundIdResponse> Handle(GetRaceIncidentsByRoundIdRequest request, CancellationToken cancellationToken)
        {
            return new GetRaceIncidentsByRoundIdResponse (await _query.ExecuteAsync(request.roundId));
        }
    }
}