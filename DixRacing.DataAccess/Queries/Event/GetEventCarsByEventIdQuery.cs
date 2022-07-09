using Dapper;
using DixRacing.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Event
{
    public class GetEventCarsByEventIdQuery : IGetEventCarsByEventIdQuery
    {
        private const string SqlString = @"select ec.*,c.* 
            from EventCars ec 
            join Cars c 
            on ec.CarId = c.Id 
            where ec.EventId=@p_EventId";
        private readonly DapperContext _dapperContext;

        public GetEventCarsByEventIdQuery(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<EventCarReadModel>> ExecuteAsync(int eventId)
        {
            using var connection = _dapperContext.GetOpenConnection();
            return await connection.QueryAsync<EventCarReadModel>(SqlString,new {p_EventId = eventId});
        }
    }
}