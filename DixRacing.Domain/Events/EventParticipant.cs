using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Teams;
using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Events
{
    public class EventParticipant : BaseEntity<int>
    {
        public EventParticipant() : base(default)
        {
        }
        public int UserId {get;set;}
        public int EventId { get; set; }
        public Event Event {get;set;}
        public int Car { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }
        public Team Team {get;set;}
        public byte[] Livery { get; set; }
    }
}