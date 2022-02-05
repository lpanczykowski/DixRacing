using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Response
{
    public class RaceResultsResponse
    {
        public double Points { get; set; }
        public double PentaltyPoints { get; set; }
        public string SteamId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }
    }
}