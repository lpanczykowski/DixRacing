using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Utility
{
    public class Car : BaseEntity
    {   
        public int GameId { get; set; }
        public int EventId { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }

    }
}