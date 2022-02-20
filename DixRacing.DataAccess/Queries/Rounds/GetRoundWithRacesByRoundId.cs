using Dapper;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Rounds.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Rounds
{
    public class GetRoundWithRacesByRoundIdQuery : IGetRoundWithRacesByRoundIdQuery
    {
        private const string SqlString = @"select
	      r.*, r2.* 
          from Rounds r  
	        join Races r2 
	        on r.Id  = r2.RoundId 
          where r.Id  = @P_RoundId ;";
        private readonly DapperContext _dapperContext;

        public GetRoundWithRacesByRoundIdQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<RoundWithRacesReadModel> ExecuteAsync(int roundId)
        {
            using var connection = _dapperContext.GetOpenConnection();
            var roundDictionary = new Dictionary<int, RoundWithRacesReadModel>();
            await connection.QueryAsync<RoundWithRacesReadModel, RaceReadModel, RoundWithRacesReadModel>(
                SqlString,
                (round, race) =>
                {
                    if (!roundDictionary.TryGetValue(round.Id, out var roundReadModel))
                    {
                        roundReadModel = round;
                        roundDictionary.Add(round.Id,round);
                    }

                    if (race is not null)
                    {
                        roundReadModel.Races.Add(race);
                    }
                    return round;

                }, new { P_RoundId = roundId });

            return roundDictionary.Values.SingleOrDefault();
        }
    }
}