using MediatR;

namespace API.Features.Rounds.Queries.GetRoundWithRaces
{
    public record GetRoundWithRacesRequest(int Id) : IRequest<GetRoundWithRacesResponse>;
 
        
 
}