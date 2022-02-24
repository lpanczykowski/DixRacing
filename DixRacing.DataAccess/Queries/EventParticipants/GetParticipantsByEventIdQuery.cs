using Dapper;
using DixRacing.Domain.Events.Queries;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Users.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.EventParticipants
{
    public class GetParticipantsByEventIdQuery : IGetParticipantsByEventIdQuery
    {
        private const string SqlString = @"
        SELECT Count(*) from EventParticipants where EventId = @p_EventId;
        SELECT  ev.Car ,ev.number,u.Name ,u.Surname ,u.Nick ,t.Name TeamName from EventParticipants ev 
            join Users u on ev.UserId = u.Id 
            join Teams t on ev.TeamId  = t.Id 
        where ev.EventId = @p_EventId
        order by ev.UserId
        limit @p_limit
        offset @p_offset";
        private readonly DapperContext _context;

        public GetParticipantsByEventIdQuery(DapperContext context)
        {
            _context = context;
        }
        public async Task<PaginatedResult<EventParticipantReadModel>> ExecuteAsync(EventParticipantPaginatedRequest request)
        {
            using var connection = _context.GetOpenConnection();
            var multi = await connection.QueryMultipleAsync(SqlString,
                new
                {
                    p_EventId = request.EventId,
                    p_limit = request.PageSize,
                    p_offset = PaginationOffset.GetOffset(request.PageSize, request.PageNumber)
                });
            var totalRowCount = multi.Read<int>().Single();
            var Rows = multi.Read<EventParticipantReadModel>().AsEnumerable();
            return new PaginatedResult<EventParticipantReadModel>(Rows,totalRowCount,request.PageNumber,request.PageSize);
        }
    }
}