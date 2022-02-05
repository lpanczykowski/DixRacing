using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class AttachDiscordRequest
    {
        public string DiscordId { get; set; }
        public int UserId { get; set; }
    }
}