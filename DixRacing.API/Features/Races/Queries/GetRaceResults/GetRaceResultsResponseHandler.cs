using AutoMapper;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Races.Queries.GetRaceResults
{
    public class GetRaceResultsResponseHandler : IRequestHandler<GetRaceResultsRequest, IEnumerable<GetRaceResultsResponse>>
    {
        private readonly IGetRaceResultsQuery _query;
        private readonly IMapper _mapper;

        public GetRaceResultsResponseHandler(IGetRaceResultsQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetRaceResultsResponse>> Handle(GetRaceResultsRequest request, CancellationToken cancellationToken)
        {
            var result = await _query.ExecuteAsync(request.RaceId, request.SessionType);
            return _mapper.Map<IEnumerable<UserRaceResultReadModel>, IEnumerable<GetRaceResultsResponse>>(result);
            
        }
    }
}