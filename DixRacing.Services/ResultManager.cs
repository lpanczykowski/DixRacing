using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Data.Models.ResultModels;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class ResultManager : IResultManager
    {
        private readonly DataContext _dataContext;
        private readonly IRaceRepository _raceRepository;
        private readonly IRoundsRepository _roundsRepository;

        public ResultManager(DataContext dataContext,
                                IRaceRepository raceRepository,
                                IRoundsRepository roundsRepository)
        {
            _dataContext = dataContext;
            _raceRepository = raceRepository;
            _roundsRepository = roundsRepository;
        }

        public async Task<int> ManageResults(Results results)
        {

            if (results.sessionType.Contains("R"))
            {
                await AddRaceResultsAsync(results);

            }

            return 0;
        }

        public async Task<int> AddRaceResultsAsync(Results results)
        {
            var round = await _roundsRepository.FindRoundByTrackAndDate(results.trackName, results.sessionDate);
            var position = 0;
            foreach (var result in results.sessionResult.leaderBoardLines)
            {
                position++;
                if (round.Races.Count() == 1 )
                {
                    var raceResults = new RaceResults (){
                        RaceId = round.Races.Select(s=>s.RaceId).FirstOrDefault(),
                        Position = position,
                        UserId =  await _dataContext.Users.Where(x=>x.SteamId == result.currentDriver.playerId).Select(s=>s.UserId).FirstOrDefaultAsync(),
                        Points =  await _dataContext.RacePoints.Where(x=>x.RaceId == round.Races.Select(s => s.RaceId)
                                                                                                .FirstOrDefault() && x.Position == position)
                                                               .Select(s=>s.Points)
                                                               .FirstOrDefaultAsync(),
                        PenaltyPoints = 0
                    };
                    await _dataContext.AddAsync(raceResults);
                }
                else
                {

                }

            }
            return await _dataContext.SaveChangesAsync();

        }


    }
}