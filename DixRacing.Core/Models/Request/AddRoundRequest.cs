using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.Request
{
    public class AddRoundRequest
    {
        public int TrackID { get; set; }
        public string ServerPassword { get; set; }
        public string ServerName { get; set; }
    }
}