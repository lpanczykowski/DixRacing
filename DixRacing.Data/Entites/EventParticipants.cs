using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class EventParticipants
    {
        [Key]
        public int EventParticipantsId{get;set;} 
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Car { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public byte[] Livery { get; set; }
        
        [ForeignKey("UserId")]
        public Users User { get; set; }
    }
}