using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Races
{
    public class RaceLap
    {
        [Key]
        public int RaceLapId { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int Time { get; set; }
    }
}