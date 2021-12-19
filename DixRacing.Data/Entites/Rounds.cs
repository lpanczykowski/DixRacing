using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Rounds
    {
        [Key]
        public int RoundId { get; set; }
        public int EventId { get; set; }
        [ForeignKey("RaceId")]
        public ICollection<Races> Races { get; set; }
        public string ServerName { get; set; }
        public string ServerPassword { get; set; }
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Tracks Track { get; set; }

    }
}