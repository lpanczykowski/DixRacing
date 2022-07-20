using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Rounds.Queries
{
    public interface IGetRaceIncidentsByRoundIdQuery
    {
        Task<IList<RoundIncidentsReadModel>> ExecuteAsync(int roundId);
    }
}