using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Rounds.Queries;
using DixRacing.Domain.Tracks.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetEventWithRoundsByEventIdQuery : IGetEventWithRoundsByEventIdQuery
    {
        private const string SqlString = @"select e.*
               ,r.*
               ,t.*
        from Events e 
        join Rounds r     
        on e.Id  = r.EventId 
        join Tracks t on r.TrackId = t.Id 
        where e.Id = @p_EventId";
        private readonly DapperContext _dapperContext;

        public GetEventWithRoundsByEventIdQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<EventReadModel> ExecuteAsync(int eventId)
        {
            using var connection = _dapperContext.GetOpenConnection();
            var eventDictionary = new Dictionary<int,EventReadModel>();
            var roundDictionary  = new Dictionary<int,RoundReadModel>();
            await connection.QueryAsync<EventReadModel, RoundReadModel,TrackReadModel, EventReadModel>(
            SqlString,
            (e,r, t) =>
            {
                if (!eventDictionary.TryGetValue(e.Id, out var eventReadModel))
                {
                    eventReadModel = e;
                    eventDictionary.Add(e.Id, e);
                }
                if (r is not null)
                {
                    eventReadModel.Rounds.Add(new RoundReadModel(r.Id, r.ServerName, r.ServerPassword, r.RoundNumber,
                        r.isActive, r.RoundDay, t));
                }
                return e;
            }, new {p_EventId = eventId}
            );
            return eventDictionary.Values.SingleOrDefault();
        }
    }
}