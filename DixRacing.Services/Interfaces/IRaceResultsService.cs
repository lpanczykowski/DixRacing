using DixRacing.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services.Interfaces
{
    public interface IRaceResultsService
    {
        Task<ICollection<RaceResultsResponse>> FindRaceResultsByRaceId(int raceId);
    }
}