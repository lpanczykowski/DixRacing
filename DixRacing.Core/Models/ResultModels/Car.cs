using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.ResultModels
{
    public class Car
    {
        public int carId { get; set; }
        public int raceNumber { get; set; }
        public int carModel { get; set; }
        public int cupCategory { get; set; }
        public string teamName { get; set; }
        public int nationality { get; set; }
        public int carGuid { get; set; }
        public int teamGuid { get; set; }
        public List<Driver> drivers { get; set; }
    }
}