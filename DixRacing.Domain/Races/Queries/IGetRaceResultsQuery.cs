using DixRacing.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public interface IGetRaceResultsQuery
    {
        Task <IEnumerable<UserRaceResultReadModel>> ExecuteAsync(int raceId, string sessionType);
    }
}