using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.Domain.Tracks.Queries;

public interface IGetAllTracksQuery
{
    Task<IEnumerable<TrackReadModel>> ExecuteAsync(int gameId);
}