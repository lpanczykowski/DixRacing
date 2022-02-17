using MediatR;

namespace API.Features.Rounds.Queries.GetAllRounds
{
    public record GetAllRoundsRequest : IRequest<GetAllRoundsResponse>;

}