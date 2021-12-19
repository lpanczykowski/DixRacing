using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class RacePoints
    {
        [Key]
        public int RacePointId { get; set; }
        public int RaceId { get; set; }
        public int Position { get; set; }
        public double Points { get; set; }
    }
}