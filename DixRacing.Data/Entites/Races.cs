using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Races
    {
        [Key]
        public int RaceId { get; set; }

        public int RoundId{get;set;}
        [ForeignKey("EventId")]
        public Events Event { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime SigningTime { get; set; }
        public int MaxPlayers { get; set; }        
        public Weathers Weather {get;set;}
    
    }
}