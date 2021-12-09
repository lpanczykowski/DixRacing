using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class RaceHotLaps
    {
        [Key]
        public int RaceHotLapId { get; set; }
        public int RaceId { get; set; }
        [ForeignKey("RaceId")]
        public Races Race { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public int Time { get; set; }
    }
}