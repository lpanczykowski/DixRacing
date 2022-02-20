using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Races
{
    public class HotLap
    {
        [Key]
        public int RaceHotLapId { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int UserId { get; set; }
        public int Time { get; set; }
    }
}