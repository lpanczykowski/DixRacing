using DixRacing.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.Races.Queries.GetRaceResults
{
    public record GetRaceResultsResponse(int UserId, string Name, string Surname, string Nick, RacePointsDto Position, LapDto BestLap, IEnumerable<LapDto> Laps,int Time, int Gap)
    {

    }
    public record RacePointsDto(int Position, int Points);
    public record LapDto(int Lap, int Split1, int Split2, int Split3, int IsValid);
}