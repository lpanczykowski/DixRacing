using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class AddRoundRequest
    {
        public int TrackId { get; set; }
        public string ServerPassword { get; set; }
        public string ServerName { get; set; }
        public int EventId { get; set; }
        public DateTime RoundDay { get; set; }
    }
}