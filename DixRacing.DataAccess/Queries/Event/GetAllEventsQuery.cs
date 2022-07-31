using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.Rounds.Queries;
using DixRacing.Domain.Tracks.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetAllEventsQuery : IGetAllEventsQuery
    {
        private string SqlString = @"select e.*
               ,r.*
               ,t.*
        from Events e 
        join Rounds r     
        on e.Id  = r.EventId 
        join Tracks t on r.TrackId = t.Id";
        private readonly DapperContext _dapperContext;

        public GetAllEventsQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<EventReadModel>> ExecuteAsync(bool onlyActiveEvents = false)
        {
            using var connection = _dapperContext.GetOpenConnection();
            var eventDictionary = new Dictionary<int,EventReadModel>();
            var roundDictionary  = new Dictionary<int,RoundReadModel>();
            if (onlyActiveEvents) SqlString = SqlString + " where r.IsActive = 1";
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
                }
            );
            return eventDictionary.Values.AsEnumerable();

        }
    }
}
