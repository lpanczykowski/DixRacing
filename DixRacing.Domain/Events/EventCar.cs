using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Events
{
    public class EventCar : BaseEntity
    {
        public int EventId { get; set; }    
        public int CarId { get; set; }
        public Event Event { get; set; }
        public Car Car { get; set; }
    }
}