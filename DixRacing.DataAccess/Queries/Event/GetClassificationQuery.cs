using Dapper;
using DixRacing.Domain.Events;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Races;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.Rounds.Queries;
using DixRacing.Domain.Teams;
using DixRacing.Domain.Teams.Queries;
using DixRacing.Domain.Users;
using DixRacing.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetClassificationQuery : IGetEventClassificationQuery
    {
        private const string SqlString = @"
            select
	            ep.*,u.*,t.*,r.*,r2.*,rr.*  
            from EventParticipants ep 
            join Users u on ep.UserId  = u.Id 
            left join Teams t on ep.TeamId  = t.Name 
            left join Rounds r on ep.EventId  = r.EventId
            left join Races r2  on r.Id  = r2.RoundId
            left join RaceResults rr on r2.Id  = rr.RaceId
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
            var result = await connection.QueryAsync<EventParticipantReadModel, UserReadModel, TeamReadModel, RoundReadModel, RaceReadModel, RaceResultReadModel, EventClassificationReadModel>
            (SqlString,
                (eventParticipant, user, team, round, race, raceResult) =>
                {
                    if (!eventClassificationDict.TryGetValue(eventParticipant.Number, out var eventClassificationReadModel))
                    {
                        eventClassificationReadModel = new EventClassificationReadModel(
                        eventId,
                        raceResult.Position,
                        eventParticipant.Number,
                        user.Name,
                        user.Surname,
                        team.Name,
                        eventParticipant.Car,
                        new List<double>(), raceResult.Points);
                        eventClassificationDict.Add(eventParticipant.Number,eventClassificationReadModel);
                    }
                    if (raceResult is not null)
                    {
                        eventClassificationReadModel.RacePoints.Add(raceResult.Points);
                    }

                    return eventClassificationReadModel;

                }, new { p_eventId = eventId },splitOn : "Id"
            );
            return eventClassificationDict.Values.ToList();
        }
    }
}