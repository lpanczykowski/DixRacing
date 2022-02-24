using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using System.Collections.Generic;

namespace DixRacing.Domain.Teams
{
    public class Team : BaseEntity<int>
    {
        public Team() : base(default)
        {
        }
        public string Name { get; set; }
        public IEnumerable<EventParticipant> Participants { get; set; }
    }
}