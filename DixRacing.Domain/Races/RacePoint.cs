using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Races
{
    public class RacePoint
    {
        [Key]
        public int RacePointId { get; set; }
        public int RaceId { get; set; }
        public int Position { get; set; }
        public double Points { get; set; }
    }
}