using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class AddPenaltyPointsRequest
    {
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int PenaltyPoints { get; set; }
    }
}