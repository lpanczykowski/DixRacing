using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Events
{
    public class EventParticipant
    {
        [Key]
        public int EventParticipantsId { get; set; }
        public int EventId { get; set; }
        public int Car { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public byte[] Livery { get; set; }
    }
}