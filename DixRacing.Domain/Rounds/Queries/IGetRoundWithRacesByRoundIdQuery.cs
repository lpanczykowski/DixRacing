using System.Threading.Tasks;

namespace DixRacing.Domain.Rounds.Queries
{
    public interface IGetRoundWithRacesByRoundIdQuery
    {
        Task<RoundWithRacesReadModel> ExecuteAsync(int roundId);
    }
}