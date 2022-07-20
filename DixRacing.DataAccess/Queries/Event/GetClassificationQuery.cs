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
        private const string SqlString = @"
            select
	            ep.*,u.*,t.*,r.*,r2.*,rr.*,rp.*,ri.PointsPenalty
            from EventParticipants ep 
            join Users u on ep.UserId  = u.Id 
            left join Teams t on ep.TeamId  = t.Name 
            left join Rounds r on ep.EventId  = r.EventId
            left join Races r2  on r.Id  = r2.RoundId
            left join RaceResults rr on rr.UserId = u.id
            left join RacePoints rp on rr.RaceId = rp.RaceId and rp.Position = rr.Position
            left join RaceIncidents ri on rr.RaceId =ri.RaceId and rr.UserId =ri.ReportedUserId
            where ep.eventId  == @p_eventId";
        private readonly DapperContext _dapper;

        public GetClassificationQuery(DapperContext dapper)
        {
            _dapper = dapper;
        }
        public async Task<ICollection<EventClassificationReadModel>> ExecuteAsync(int eventId)
        {
            using var connection = _dapper.GetOpenConnection();
            var eventClassificationDict = new Dictionary<int, EventClassificationReadModel>();
            var result = await connection.QueryAsync<EventClassificationReadModel,RoundClassificationReadModel,EventClassificationReadModel>
            (SqlString,
                (ec,rc) =>
                {
                    if (!eventClassificationDict.TryGetValue(ec.Number, out var eventClassificationReadModel))
                    {
                        eventClassificationReadModel = new EventClassificationReadModel(
                        eventId,
                        ec.Number,
                        ec.Name,
                        ec.Surname,
                        ec.TeamName,
                        ec.Car,
                        new List<RoundClassificationReadModel>(),
                        new RacePointsReadModel(),
                        ec.PointPenalty
                        );//TODO: RacePoints
                        eventClassificationDict.Add(ec.Number,eventClassificationReadModel);
                    }
                         //TODO:RacePoints RacePointsClassificationRM
                     

                    return eventClassificationReadModel;

                }, new { p_eventId = eventId },splitOn : "Id"
            );
            return eventClassificationDict.Values.ToList();
        }
    }
}