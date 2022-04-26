using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races
{
    public class RaceIncident : BaseEntity
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int ReportedUserId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int? IsSolved { get; set; }
        public int Time { get; set; }
        public int Lap { get; set; }
        public int? PointPenalty { get; set; }
        public int? TimePenalty { get; set; }
        public string Penalty { get; set; }
    }
}