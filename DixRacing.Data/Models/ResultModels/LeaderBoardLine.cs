using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.ResultModels
{
    public class LeaderBoardLine
    {
        public Car car { get; set; }
        public CurrentDriver currentDriver { get; set; }
        public int currentDriverIndex { get; set; }
        public Timing timing { get; set; }
        public int missingMandatoryPitstop { get; set; }
        public List<object> driverTotalTimes { get; set; }

    }
}