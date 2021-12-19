using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.ResultModels
{
    public class SessionResult
    {
        public int bestlap { get; set; }
        public List<int> bestSplits { get; set; }
        public int isWetSession { get; set; }
        public int type { get; set; }
        public List<LeaderBoardLine> leaderBoardLines { get; set; }
    }
}