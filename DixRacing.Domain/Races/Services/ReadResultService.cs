using DixRacing.Domain.Races;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Services
{
    public interface IReadResultService
    {
        Task<bool> ReadResultAccAsync(AccResult accResult);

    }
    public class ReadResultService
    {
        private readonly IRepository<Round> _roundRepository;
        private readonly IRepository<Race> _raceRepository;
        private readonly IRepository<RaceResult> _raceResultRepository;
        private readonly IRepository<RaceLap> _raceLapRepository;
        private readonly IRepository<User> _userRepository;

        public ReadResultService(IRepository<Round> roundRepository,
                                 IRepository<Race> raceRepository,
                                 IRepository<RaceResult> raceResultRepository,
                                 IRepository<RaceLap> raceLapRepository,
                                 IRepository<User> userRepository)
        {
            _roundRepository = roundRepository;
            _raceRepository = raceRepository;
            _raceResultRepository = raceResultRepository;
            _raceLapRepository = raceLapRepository;
            _userRepository = userRepository;
        }


        public async Task<bool> ReadResultAccAsync(AccResult accResult)
        {
            var round = await _roundRepository.GetUniqueByPropertyAsync(x => x.ServerName == accResult.ServerName);
            var race = await _raceRepository.GetUniqueByPropertyAsync(x => x.RoundId == round.Id && x.SessionType == accResult.SessionType);
            if (race is null) return false;
            var driverResults = GetAllDriverLaps(accResult);
            var raceLaps = new List<RaceLap>();
            var position = 1;
            foreach (var (driver, laps) in driverResults)
            {
                raceLaps.AddRange(AddRaceLaps(race, driver, laps));
                var user = await _userRepository.GetUniqueByPropertyAsync(x => x.SteamId == driver.PlayerId.Substring(1));
                if (user is not null)
                {
                    await UpdateRaceResult(race, position, user);
                }
                ++position;
            }

            await _raceLapRepository.CreateMultipleAsync(raceLaps);
            return true;

        }

        private List<RaceLap> AddRaceLaps(Race race, Driver driver, List<Lap> laps)
        {
            var raceLaps = new List<RaceLap>();
            foreach (var lap in laps)
            {
                raceLaps.Add(new RaceLap()
                {
                    Lap = lap.Laptime,
                    Split1 = lap.Splits[0],
                    Split2 = lap.Splits[1],
                    Split3 = lap.Splits[2],
                    RaceId = race.Id,
                    UserSteamId = driver.PlayerId.Substring(1),
                    IsValid = Convert.ToInt16(lap.IsValidForBest),
                });
            }
            return raceLaps;
        }

        private async Task UpdateRaceResult(Race race, int position, User user)
        {
            var raceResult = await _raceResultRepository.GetUniqueByPropertyAsync(x => x.UserId == user.Id && x.RaceId == race.Id);
            if (raceResult is not null)
                raceResult.Position = position;
            _raceResultRepository.Update(raceResult);
        }

        private Driver GetDriverForLap(Lap lap, List<LeaderBoardLine> leaderBoardLines)
        {
            return leaderBoardLines.Where(x => x.Car.CarId == lap.CarId).Select(x => x.Car.Drivers[lap.DriverIndex]).FirstOrDefault();
        }
        private Dictionary<Driver, List<Lap>> GetAllDriverLaps(AccResult accResult)
        {
            var driverLapsDict = new Dictionary<Driver, List<Lap>>();
            foreach (var leaderBoardLine in accResult.SessionResult.LeaderBoardLines)
            {
                foreach (var driver in leaderBoardLine.Car.Drivers)
                {
                    if (!driverLapsDict.TryGetValue(driver, out var Laps))
                    {
                        Laps = accResult.Laps.Where(x => x.CarId == leaderBoardLine.Car.CarId
                                                         && x.DriverIndex == leaderBoardLine.Car.Drivers.IndexOf(driver)).ToList();
                        driverLapsDict.Add(driver, Laps);
                    }

                }



            }
            return driverLapsDict;
        }

    }
}