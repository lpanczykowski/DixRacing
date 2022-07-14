using Dapper;
using DixRacing.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetAllEventsQuery : IGetAllEventsQuery
    {
        private string SqlString = @"
        select e.Id as EventId,
	           e.Name,
               e.Photo,  
               r.Id as RoundId,
               r.RoundDay,
               (select count(*) from Rounds r2 where r2.EventId = e.Id) as AmountOfRounds      
        from Events e
        left join Rounds r on e.Id = r.EventId";
        private readonly DapperContext _dapperContext;

        public GetAllEventsQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<EventCaptionReadModel>> ExecuteAsync(bool onlyActiveEvents = false)
        {
            if (onlyActiveEvents) SqlString = SqlString + " where r.isActive = true";
            using var connection = _dapperContext.GetOpenConnection();
            return await connection.QueryAsync<EventCaptionReadModel>(SqlString);

        }
    }
}
