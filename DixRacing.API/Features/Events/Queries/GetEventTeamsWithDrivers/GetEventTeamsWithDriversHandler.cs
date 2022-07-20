using DixRacing.Domain.Events.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetEventTeamsWithDrivers
{
    public class GetEventTeamsWithDriversHandler : IRequestHandler<GetEventTeamsWithDriversRequest, GetEventTeamsWithDriversResponse>
    {
    private readonly IGetEventTeamsWithDriversQuery _query;
        public GetEventTeamsWithDriversHandler(IGetEventTeamsWithDriversQuery query)
        {
            _query = query;
        }

        public async Task<GetEventTeamsWithDriversResponse> Handle(GetEventTeamsWithDriversRequest request, CancellationToken cancellationToken)
        {
            return new GetEventTeamsWithDriversResponse (await _query.ExecuteAsync(request.eventId));
        }
    }
}