using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class RaceResults
    {
        [Key]
        public int RaceResultId {get;set;}
        public int UserId { get; set; }
        public int RaceId { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }               
        public int Position { get; set; }
        public double Points  { get; set; } = 0;
        public int? PenaltyPoints { get; set; }
    }
}