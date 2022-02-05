using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class GetEventParticipantsRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Car { get; set; }
        public int Team { get; set; }
        public int CarNumber { get; set; }
    }
}