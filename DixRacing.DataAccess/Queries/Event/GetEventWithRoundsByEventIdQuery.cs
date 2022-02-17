using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Rounds.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetEventWithRoundsByEventIdQuery : IGetEventWithRoundsByEventIdQuery
    {
        private const string SqlString = @"
        select e.*
               ,r.*
        from Events e 
        join Rounds r 
        on e.Id  = r.EventId where e.Id = @EventId ";
        private readonly DapperContext _dapperContext;

        public GetEventWithRoundsByEventIdQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<EventReadModel> ExecuteAsync(int eventId)
        {
            using var connection = _dapperContext.GetOpenConnection();
            var eventDictionary = new Dictionary<int,EventReadModel>();
            await connection.QueryAsync<EventReadModel, RoundReadModel, EventReadModel>(
            SqlString,
            (e, r) =>
            {
                if (!eventDictionary.TryGetValue(e.Id, out var eventReadModel))
                {
                    eventReadModel = e;
                    eventDictionary.Add(e.Id, e);
                }

                if (r is not null)
                {
                    eventReadModel.Rounds.Add(r);
                }

                return e;
            }, new {EventId = eventId}
            );
            return eventDictionary.Values.SingleOrDefault();
        }
    }
}