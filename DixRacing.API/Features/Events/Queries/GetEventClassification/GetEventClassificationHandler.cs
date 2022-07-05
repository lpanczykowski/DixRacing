using DixRacing.Domain.Events.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetEventClassification
{
    public class GetEventClassificationHandler : IRequestHandler<GetEventClassificationRequest, GetEventClassificationResponse>
    {
        private readonly IGetEventClassificationQuery _query;

        public GetEventClassificationHandler(IGetEventClassificationQuery query)
        {
            _query = query;
        }

        public async Task<GetEventClassificationResponse> Handle(GetEventClassificationRequest request, CancellationToken cancellationToken)
        {
            return new GetEventClassificationResponse(await _query.ExecuteAsync(request.EventId));
        }
    }
}