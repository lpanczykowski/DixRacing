using DixRacing.Domain.Races.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Users.Queries
{
    public class UserRaceResultReadModel

    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public RacePointsReadModel Position { get; set; }
        public RaceLapReadModel BestLap { get; set; }
        public List<RaceLapReadModel> Laps { get; set; }
        public int Time { get; set; }
        public int Gap { get; set; }
        public UserRaceResultReadModel(int UserId,
                                       string Name,
                                       string Surname,
                                       string Nick,
                                       RacePointsReadModel Position,
                                       List<RaceLapReadModel> Laps,
                                       int Time,
                                       int Gap)
        {
            this.BestLap = Laps.Where(x => x.IsValid == 1).OrderBy(x => x.Lap).FirstOrDefault(); ;
            this.UserId = UserId;
            this.Name = Name;
            this.Surname = Surname;
            this.Nick = Nick;
            this.Position = Position;
            this.Laps = Laps;
            this.Time = Time;
            this.Gap = Gap;
        }
    }
}