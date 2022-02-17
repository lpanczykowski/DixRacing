using System.Collections.Generic;

namespace API.Features.Rounds.Queries.GetAllRounds
{
    public record GetAllRoundsResponse(IEnumerable<RoundsDto> Events);
    public record RoundsDto(int roundId);

}