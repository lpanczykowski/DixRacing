using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace DixRacing.Domain.Events
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public int GameId { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<EventParticipant.EventParticipant> EventParticipants { get; set; }
    }
}