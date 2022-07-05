using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Rounds.Queries.GetAllRounds
{
    public class GetAllRoundsHandler : IRequestHandler<GetAllRoundsRequest, GetAllRoundsResponse>
    {
        public Task<GetAllRoundsResponse> Handle(GetAllRoundsRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}