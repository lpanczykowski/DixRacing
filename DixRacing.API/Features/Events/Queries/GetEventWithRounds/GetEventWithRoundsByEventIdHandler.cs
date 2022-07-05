using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.SharedKernel.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Events.Queries.GetEventWithRounds
{
    public class GetEventWithRoundsByEventIdHandler : IRequestHandler<GetEventWithRoundsByEventIdRequest, GetEventWithRoundsByEventIdResponse>
    {
        private readonly IGetEventWithRoundsByEventIdQuery _query;

        public GetEventWithRoundsByEventIdHandler(IGetEventWithRoundsByEventIdQuery query)
        {
            _query = query;
        }

        public async Task<GetEventWithRoundsByEventIdResponse> Handle(GetEventWithRoundsByEventIdRequest request, CancellationToken cancellationToken)
        {
            var e = await _query.ExecuteAsync(request.Id);
            if (e is null)  throw new EntityNotFoundException(nameof(e), request.Id.ToString());
            return new GetEventWithRoundsByEventIdResponse(e);
        }
    }
}