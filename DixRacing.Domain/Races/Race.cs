using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Races
{
    public class Race : BaseEntity
    {

        public int RoundId { get; set; }
        public Round Round { get; set; }
        public DateTime PracticeDate { get; set; }
        public int PracticeLength { get; set; }
        public DateTime QualiDate { get; set; }
        public int QualiLength { get; set; }
        public DateTime RaceDate { get; set; }
        public int RaceLength { get; set; }
        public DateTime SigningTime { get; set; }
        public int MaxPlayers { get; set; }
        public ICollection<RaceResult> RaceResults { get; set; }
        public ICollection<RaceLap> RaceLaps { get; set; }
        public ICollection<RacePoint> RacePoints { get; set; }
        public string SessionType { get; set; }

    }
}