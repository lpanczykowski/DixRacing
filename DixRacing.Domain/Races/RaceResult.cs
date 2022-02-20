using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Races
{
    public class RaceResult
    {
        [Key]
        public int RaceResultId { get; set; }
        public int RaceId { get; set; }
        public int Position { get; set; }
        public double Points { get; set; } = 0;
        public int? PenaltyPoints { get; set; }
    }
}