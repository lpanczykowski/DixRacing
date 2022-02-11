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
        // public Rounds Round { get; set; }
        public DateTime PracticeDate { get; set; }
        public DateTime PracticeLength { get; set; }
        public DateTime QualiDate { get; set; }
        public DateTime QualiLength { get; set; }
        public DateTime RaceDate { get; set; }
        public DateTime RaceLength { get; set; }
        public int MaxPlayers { get; set; }

    }
}