using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.ResultModels
{
    public class Lap
    {
        public int carId { get; set; }
        public int driverIndex { get; set; }
        public int laptime { get; set; }
        public bool isValidForBest { get; set; }
        public List<int> splits { get; set; }
    }
}