using DixRacing.Domain.Events.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.EventParticipants.Queries
{
    public class GetParticipantsByEventIdHandler : IRequestHandler<GetParticipantsByEventIdRequest, IEnumerable<EventParticipantReadModel>>
    {
        private readonly IGetParticipantsByEventIdQuery _query;

        public GetParticipantsByEventIdHandler(IGetParticipantsByEventIdQuery query)
        {
            _query = query;
        }
        public async Task<IEnumerable<EventParticipantReadModel>> Handle(GetParticipantsByEventIdRequest request, CancellationToken cancellationToken)
        {
            return await _query.ExecuteAsync(request.EventId);
        }
    }
}