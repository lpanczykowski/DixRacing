using Dapper;
using DixRacing.Domain.Events.Queries;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.EventParticipants;

public class GetParticipantByEventIdAndUserIdQuery : IGetParticipantByEventIdAndUserIdQuery
{
    private readonly DapperContext _dapperContext;
    private const string sql = @"SELECT  ev.Car ,ev.number,u.Name ,u.Surname ,u.Nick ,t.Name TeamName from EventParticipants ev 
            join Users u on ev.UserId = u.Id 
            join Teams t on ev.TeamId  = t.Id 
        where ev.EventId = @p_EventId
        and ev.UserId = @p_UserId";

    public GetParticipantByEventIdAndUserIdQuery(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<EventParticipantReadModel> ExecuteAsync(int eventId, int userId)
    {
        using var connection = _dapperContext.GetOpenConnection();
        return await connection.QueryFirstOrDefaultAsync<EventParticipantReadModel>(sql,
                new { @p_EventId = eventId, @p_UserId = userId });
        
        
    }
}