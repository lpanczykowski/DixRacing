using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class AddRaceRequest
    {
        public int RoundId { get; set; }
        public DateTime PracticeDate { get; set; }
        public DateTime PracticeLength { get; set; } 
        public DateTime QualiDate { get; set; }
        public DateTime QualiLength { get; set; }
        public DateTime RaceDate { get; set; }
        public DateTime RaceLength { get; set; } 
        public int MaxPlayers { get; set; }
        public int TrackId { get; set; }
    }
}