using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races
{
    public class RaceResult : BaseEntity
    {
        public int RaceId { get; set; }
        public int UserId { get; set; }
        public int Position { get; set; }
        public int TotalTime { get; set; }
        public Race Race { get; set; }
        public int IsUserConfirmed { get; set; }
    }
}