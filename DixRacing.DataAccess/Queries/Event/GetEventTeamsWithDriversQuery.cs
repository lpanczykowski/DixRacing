using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Races.Queries;
using DixRacing.Domain.Teams.Queries;
using DixRacing.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetEventTeamsWithDriversQuery : IGetEventTeamsWithDriversQuery
    {
        private const string SqlString = @"select t.Name TeamName,t.Id TeamId,SUM(rp.Points) SummedPoints,u.Name UserName,
                                        u.Surname UserSurname from Teams t
                                        join EventParticipants ep  on t.Id = ep.TeamId
                                        join Users u  on ep.UserId  = u.Id
                                        left join RaceResults rr  on u.Id = rr.UserId
                                        left join Races r on rr.RaceId  = r.Id
                                        left join Rounds r2  on r.RoundId  = r2.Id and r2.EventId  = ep.EventId 
                                        left join RacePoints rp  on rp.Position = rr.Position  and r.Id  = rp.RaceId 
                                        where ep.EventId =@p_EventId
                                        Group BY u.Id";
        private readonly DapperContext _dapperContext;

        public GetEventTeamsWithDriversQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IList<EventTeamsWithDriversReadModel>> ExecuteAsync(int eventId)
        {
           using var connection = _dapperContext.GetOpenConnection();
           var eventTeamsWithDriversDictionary= new Dictionary<int,EventTeamsWithDriversReadModel>();
           var result = await connection.QueryAsync<TeamReadModel, TeamMemberReadModel,EventTeamsWithDriversReadModel>
           (SqlString,(t,tm)=>
           {
                if(!eventTeamsWithDriversDictionary.TryGetValue(t.TeamId, out var eventTeamsWithDriversReadModel))
                {
                    eventTeamsWithDriversReadModel = new EventTeamsWithDriversReadModel(
                        t.TeamId,
                        t.TeamName,
                        new List<TeamMemberReadModel>(),
                        0,
                        tm.SummedPoints);
                    eventTeamsWithDriversDictionary.Add(t.TeamId,eventTeamsWithDriversReadModel);
                }
                eventTeamsWithDriversReadModel.TeamMembers.Add(tm);
    
                return eventTeamsWithDriversReadModel;
           },new { p_EventId = eventId },splitOn:"SummedPoints"
           );
           
           return eventTeamsWithDriversDictionary.Values.ToList();
        }
    }
}