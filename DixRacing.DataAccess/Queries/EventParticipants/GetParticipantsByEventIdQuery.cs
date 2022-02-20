using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Users.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.EventParticipants
{
    public class GetParticipantsByEventIdQuery : IGetParticipantsByEventIdQuery
    {
        private const string SqlString = @"
        SELECT  * from EventParticipants ev 
        join Users u on ev.UserId = u.Id 
        where ev.EventId = @p_EventId";
        private readonly DapperContext _context;

        public GetParticipantsByEventIdQuery(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EventParticipantReadModel>> ExecuteAsync(int eventId)
        {
            using var connection = _context.GetOpenConnection();
            var eventDictionary = new Dictionary<int,EventReadModel>();
            return await connection.QueryAsync<EventParticipantReadModel>(
            SqlString,new {p_EventId = eventId});           
        }
    }
}