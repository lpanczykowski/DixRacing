using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Teams;

namespace DixRacing.Domain.EventParticipant
{
    public class EventParticipant : BaseEntity
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int Car { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public byte[] Livery { get; set; }
    }
}