using MediatR;

namespace API.Features.Dropdowns.Queries.Tracks;

public record GetDropdownTracksRequest(int GameId) : IRequest<GetDropdownResponse>
{
    
}