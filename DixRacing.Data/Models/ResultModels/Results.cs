using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.ResultModels
{
    public class Results
    {
        public string sessionType { get; set; }
        public string trackName { get; set; }
        public int sessionIndex { get; set; }
        public int raceWeekendIndex { get; set; }
        public string metaData { get; set; }
        public string serverName { get; set; }
        public SessionResult sessionResult { get; set; }
        public List<Lap> laps { get; set; }
        public List<object> penalties { get; set; }
        public List<object> post_race_penalties { get; set; }
        public DateTime sessionDate { get; set; }

    }
}