using Dapper;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Rounds.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Rounds
{
    public class GetRaceIncidentsByRoundIdQuery : IGetRaceIncidentsByRoundIdQuery
    {
        private const string SqlString=@"select r.Id RoundId,
                                        ri.Id,
                                        ri.RaceId,
                                        ri.ReportedUserId ,
                                        ri.UserId ,
                                        ri.Description ,
                                        ri.IsSolved ,
                                        ri.Time,
                                        ri.Lap,
                                        ri.PointPenalty ,
                                        ri.TimePenalty ,
                                        ri.Penalty,
                                        ri.AppealDescription 
                                        from Rounds r 
                                        join Races r2 on r2.RoundId =r.Id 
                                        join RaceIncidents ri on ri.RaceId =r2.Id 
                                        WHERE r.Id=@p_RoundId";
        private readonly DapperContext _dapperContext;

        public GetRaceIncidentsByRoundIdQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IList<RoundIncidentsReadModel>> ExecuteAsync(int roundId)
        {
            using var connection = _dapperContext.GetOpenConnection();
            var roundIncidentsDictionary= new Dictionary<int,RoundIncidentsReadModel>();
            var result = await connection.QueryAsync<RoundIncidentsReadModel,RaceIncidentReadModel,RoundIncidentsReadModel>
            (SqlString,(rdi,ri)=>
                {
                    if (!roundIncidentsDictionary.TryGetValue(rdi.RoundId, out var roundIncidentReadModel))
                    {
                        roundIncidentReadModel=new RoundIncidentsReadModel(
                            rdi.RoundId,
                            new List<RaceIncidentReadModel>()
                        );
                        roundIncidentsDictionary.Add(rdi.RoundId,roundIncidentReadModel);
                    }
                    roundIncidentReadModel.raceIncidents.Add(ri);

                    return roundIncidentReadModel;

                }, new { p_RoundId = roundId },splitOn:"Id"
            );
            return roundIncidentsDictionary.Values.ToList();
        }
    }
}