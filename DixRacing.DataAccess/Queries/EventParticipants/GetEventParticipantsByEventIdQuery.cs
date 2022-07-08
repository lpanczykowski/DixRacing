using Dapper;
using DixRacing.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.EventParticipants
{
    public class GetEventParticipantsByEventIdQuery : IGetEventParticipantsByEventIdQuery
    {
        private readonly DapperContext _dapperContext;
        private const string SqlString=@"
        SELECT  ev.Id, ev.Car ,ev.Number,u.Name ,u.Surname ,u.Nick ,t.Name TeamName from EventParticipants ev 
            join Users u on ev.UserId = u.Id 
            join Teams t on ev.TeamId  = t.Id 
        where ev.EventId = @p_EventId
        order by ev.Number
        ";

        public GetEventParticipantsByEventIdQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<EventParticipantReadModel>> ExecuteAsync(int eventId){
            using var connection = _dapperContext.GetOpenConnection();
            return await connection.QueryAsync<EventParticipantReadModel>(SqlString, new{p_EventId=eventId});
        }
    } 
}