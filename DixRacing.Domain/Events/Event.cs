using DixRacing.Domain.EventParticipants;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;
using System;
using System.Collections.Generic;

namespace DixRacing.Domain.Events
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public int GameId { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }
        public ICollection<EventCar> EventCars { get; set; }
        public string Rules { get; set; }
    }
}