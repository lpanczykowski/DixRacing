using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.ResultModels
{
    public class Timing
    {
        public object lastLap { get; set; }
        public List<int> lastSplits { get; set; }
        public object bestLap { get; set; }
        public List<object> bestSplits { get; set; }
        public object totalTime { get; set; }
        public int lapCount { get; set; }
        public object lastSplitId { get; set; }
    }
}