using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class RaceStatusRequest
    {
        public int UserId { get; set; }
        public int RaceId { get; set; }

    }
}