using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Rounds.Queries;
using DixRacing.Domain.Teams.Queries;
using DixRacing.Domain.Users.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetClassificationQuery : IGetEventClassificationQuery
    {
        private const string SqlString = @"select	ep.EventId ,ep.Number ,u.Name , u.Surname ,u.Nick ,t.Name TeamName,ep.car,coalesce(ri.PointPenalty,0) PointPenalty,
                                            (SELECT SUM(rp2.Points) from RaceResults rr2
                                            join RacePoints rp2 on rr2.RaceId = rp2.RaceId and rr2.Position = rp2.Position
                                            join Races r3 on rr2.RaceId =r3.Id 
                                            join Rounds r4 on r3.RoundId =r4.Id 
                                            join Events e on e.Id =r4.EventId 
                                            WHERE rr2.UserId=u.Id and e.Id=ep.EventId) as SummedPoints, r.Id RoundId,r2.Id RaceId,rr.Position,rp.Points
                                        from EventParticipants ep 
                                        join Users u on ep.UserId  = u.Id 
                                        left join Teams t on ep.TeamId  = t.Id left join Rounds r on ep.EventId  = r.EventId
                                        left join Races r2  on r.Id  = r2.RoundId
                                        left join RaceResults rr on rr.UserId = u.id and r2.Id ==rr.RaceId 
                                        left join RacePoints rp on rr.RaceId = rp.RaceId and rp.Position = rr.Position
                                        left join RaceIncidents ri on rr.RaceId =ri.RaceId and rr.UserId =ri.ReportedUserId
                                        where ep.eventId  ==@p_eventId";
        private readonly DapperContext _dapper;

        public GetClassificationQuery(DapperContext dapper)
        {
            _dapper = dapper;
        }
        public async Task<ICollection<EventClassificationReadModel>> ExecuteAsync(int eventId)
        {
            using var connection = _dapper.GetOpenConnection();
            var eventClassificationDict = new Dictionary<int, EventClassificationReadModel>();
            var racePointsDict = new Dictionary<int, RacePointsReadModel>();
            var result = await connection.QueryAsync<EventClassificationReadModel, RoundClassificationReadModel, RacePointsReadModel, EventClassificationReadModel>
            (SqlString,
                (ec, rc, rp) =>
                {
                    if (!eventClassificationDict.TryGetValue(ec.Number, out var eventClassificationReadModel))
                    {
                        eventClassificationReadModel = new EventClassificationReadModel(
                        ec.EventId,
                        ec.Number,
                        ec.Name,
                        ec.Surname,
                        ec.TeamName,
                        ec.Car,
                        new List<RoundClassificationReadModel>(),
                        ec.SummedPoints,
                        ec.PointPenalty
                        );//TODO: RacePoints
                        eventClassificationDict.Add(ec.Number, eventClassificationReadModel);
                    }
                    if (!eventClassificationReadModel.RoundsPoints.Any(x => x.RoundId == rc.RoundId))
                    {
                        var roundClassificationReadModel = new RoundClassificationReadModel(rc.RoundId,new List<RacePointsReadModel>());
                        eventClassificationReadModel.RoundsPoints.Add(roundClassificationReadModel);
                    }

                    var round=eventClassificationReadModel.RoundsPoints.Where(x=>x.RoundId==rc.RoundId).First();

                    if (round is not null)
                        {
                            var racePointsReadModel = new RacePointsReadModel(rp.RaceId, rp.Position, rp.Points);
                            round.RacePoints.Add(racePointsReadModel);
                        }
                   

                    return eventClassificationReadModel;

                }, new { p_eventId = eventId },splitOn:"RoundId,RaceId"
            );
            return eventClassificationDict.Values.OrderBy(x=>x.SummedPoints+x.PointPenalty).Reverse().ToList();
        }
    }
}