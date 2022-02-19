using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace DixRacing.Domain.Events
{
    public class Event : BaseEntity<int>
    {
        public Event() : base(default)
        {
        }

        public string Name { get; set; }
        public int GameId { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<EventParticipant> EventParticipants {get;set;}
    }
}