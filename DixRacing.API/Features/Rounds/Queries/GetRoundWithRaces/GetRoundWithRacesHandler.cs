using DixRacing.Domain.Rounds.Queries;
using DixRacing.Domain.SharedKernel.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Rounds.Queries.GetRoundWithRaces
{
    public class GetRoundWithRacesHandler : IRequestHandler<GetRoundWithRacesRequest, GetRoundWithRacesResponse>
    {
        private readonly IGetRoundWithRacesByRoundIdQuery _query;

        public GetRoundWithRacesHandler(IGetRoundWithRacesByRoundIdQuery query)
        {
            _query = query;
        }

        public async Task<GetRoundWithRacesResponse> Handle(GetRoundWithRacesRequest request, CancellationToken cancellationToken)
        {
            var round = await _query.ExecuteAsync(request.Id);
            if (round is null) throw new EntityNotFoundException(nameof(round), request.Id.ToString());
            return new GetRoundWithRacesResponse(round);
        }
    }
}