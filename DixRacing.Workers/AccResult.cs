using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Workers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Driver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string PlayerId { get; set; }
    }

    public class Car
    {
        public int CarId { get; set; }
        public int RaceNumber { get; set; }
        public int CarModel { get; set; }
        public int CupCategory { get; set; }
        public string CarGroup { get; set; }
        public string TeamName { get; set; }
        public int Nationality { get; set; }
        public int CarGuid { get; set; }
        public int TeamGuid { get; set; }
        public List<Driver> Drivers { get; set; }
    }

    public class CurrentDriver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string PlayerId { get; set; }
    }

    public class Timing
    {
        public object LastLap { get; set; }
        public List<int> LastSplits { get; set; }
        public object BestLap { get; set; }
        public List<object> BestSplits { get; set; }
        public object TotalTime { get; set; }
        public int LapCount { get; set; }
        public object LastSplitId { get; set; }
    }

    public class LeaderBoardLine
    {
        public Car Car { get; set; }
        public CurrentDriver CurrentDriver { get; set; }
        public int CurrentDriverIndex { get; set; }
        public Timing Timing { get; set; }
        public int MissingMandatoryPitstop { get; set; }
        public List<object> DriverTotalTimes { get; set; }
    }

    public class SessionResult
    {
        public int Bestlap { get; set; }
        public List<int> BestSplits { get; set; }
        public int IsWetSession { get; set; }
        public int Type { get; set; }
        public List<LeaderBoardLine> LeaderBoardLines { get; set; }
    }

    public class Lap
    {
        public int CarId { get; set; }
        public int DriverIndex { get; set; }
        public int Laptime { get; set; }
        public bool IsValidForBest { get; set; }
        public List<int> Splits { get; set; }
    }

    public class AccResult
    {
        public string SessionType { get; set; }
        public string TrackName { get; set; }
        public int SessionIndex { get; set; }
        public int RaceWeekendIndex { get; set; }
        public string MetaData { get; set; }
        public string ServerName { get; set; }
        public SessionResult SessionResult { get; set; }
        public List<Lap> Laps { get; set; }
        public List<object> Penalties { get; set; }
        public List<object> PostRacePenalties { get; set; }
    }





    
}