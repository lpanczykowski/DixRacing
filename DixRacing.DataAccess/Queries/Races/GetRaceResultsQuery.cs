using Dapper;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Races
{
    public class GetRaceResultsQuery : IGetRaceResultsQuery
    {
        private readonly DapperContext _dapperContext;
        const string Sql = @"
                            select 
                                u.*,rl.*,rrr.*,rp.*
                            from EventParticipants ep 
                            join Users u on ep.UserId = u.Id 
                            join Rounds r on ep.EventId = r.EventId  
                            join Races rr on r.Id  == rr.RoundId 
                            left join RaceLaps rl on rr.Id  == rl.RaceId  and u.SteamId  = rl.UserSteamId
                            left join RaceResults rrr on rrr.RaceId  == rr.Id and u.Id  == rrr.UserId 
                            left join RacePoints rp on rp.RaceId = rr.Id and rrr.Position == rp.Position
                            where rr.SessionType = @p_sessionType and rl.RaceId = @p_raceId";

        public GetRaceResultsQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<UserRaceResultReadModel>> ExecuteAsync(int raceId, string? sessionType)
        {
            using var connection = _dapperContext.GetOpenConnection();
            var userRaceResultDict = new Dictionary<int, UserRaceResultReadModel>();
            var result = await connection.QueryAsync<UserReadModel, RaceLapReadModel, RaceResultReadModel, RacePointReadModel, UserRaceResultReadModel>(Sql,
            (user, raceLap, raceResult, racePoint) =>
            {
                if (!userRaceResultDict.TryGetValue(user.Id, out var userRaceResultReadModel))
                {
                    userRaceResultReadModel = new UserRaceResultReadModel(user.Id,
                                                                          user.Name,
                                                                          user.Surname,
                                                                          user.Nick,
                                                                          new RacePointReadModel(raceResult.Position, racePoint.Points),
                                                                          new List<RaceLapReadModel>()); ;
                    userRaceResultDict.Add(user.Id, userRaceResultReadModel);
                }
                if (raceResult is not null)
                {
                    userRaceResultReadModel.Laps.Add(raceLap);
                    if (userRaceResultReadModel.BestLap is not null)
                        userRaceResultReadModel.BestLap = raceLap.Lap < userRaceResultReadModel.BestLap.Lap ? raceLap : userRaceResultReadModel.BestLap;
                    else
                        userRaceResultReadModel.BestLap = raceLap;
                }
                return userRaceResultReadModel;
            }, new { p_sessionType = sessionType, p_raceId = raceId });
            return userRaceResultDict.Values.ToList();
        }
    }
}