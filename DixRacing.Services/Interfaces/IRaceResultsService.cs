using DixRacing.Data.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IRaceResultsService
    {
        Task<ICollection<RaceResultsResponse>> FindRaceResultsByRaceId(int raceId);
    }
}