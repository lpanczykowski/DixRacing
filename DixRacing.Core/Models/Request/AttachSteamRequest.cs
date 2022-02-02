using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.Request
{
    public class AttachSteamRequest
    {
        public string SteamId { get; set; }
        public int UserId { get; set; }
    }
}