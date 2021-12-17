using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.Request
{
    public class AddRaceRequest
    {
        public int RoundId { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime SigningTime { get; set; }
        public int MaxPlayers { get; set; }
        public int TrackId { get; set; }
    }
}