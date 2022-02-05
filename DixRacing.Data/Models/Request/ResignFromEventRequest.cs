using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Request
{
    public class ResignFromEventRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }

        
    }
}