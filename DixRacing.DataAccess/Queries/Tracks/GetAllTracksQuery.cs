using Dapper;
using DixRacing.Domain.Tracks.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.Queries.Tracks;

public class GetAllTracksQuery : IGetAllTracksQuery
{
    private readonly DapperContext _context;
    private const string sql = @"select t.* from Tracks t  where t.gameId = @p_gameId";

    public GetAllTracksQuery(DapperContext context )
    {
        _context = context;
    }

    public async Task<IEnumerable<TrackReadModel>> ExecuteAsync(int gameId)
    {
        using var connection = _context.GetOpenConnection();
        return await connection.QueryAsync<TrackReadModel>(sql, new {p_gameId = gameId});
    }
}