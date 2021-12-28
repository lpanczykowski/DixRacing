using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.Request
{
    public class CarChangeRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Car { get; set; }
    }
}