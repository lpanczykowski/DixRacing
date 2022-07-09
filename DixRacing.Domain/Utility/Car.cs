using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Utility
{
    public class Car : BaseEntity
    {   
        public int GameId { get; set; }
        public string CarName { get; set; }
        public ICollection<EventCar> EventCars { get; set; }

    }
}