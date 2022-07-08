using DixRacing.Domain.Events.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.EventParticipants.Queries.GetParticipantByEventId;

public class GetParticipantByEventIdHandler : IRequestHandler<GetParticipantByEventIdRequest, GetParticipantByEventIdResponse>
{
    private readonly IGetParticipantByEventIdAndUserIdQuery _query;

    public GetParticipantByEventIdHandler(IGetParticipantByEventIdAndUserIdQuery  query)
    {
        _query = query;
    }
    public async Task<GetParticipantByEventIdResponse> Handle(GetParticipantByEventIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _query.ExecuteAsync(request.eventId, request.userId);
        return new GetParticipantByEventIdResponse(result);
    }
}