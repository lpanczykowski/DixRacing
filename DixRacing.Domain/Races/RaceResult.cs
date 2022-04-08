using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Races
{
    public class RaceResult : BaseEntity<int>
    {
        public RaceResult(int id) : base(id)
        {

        }

        public int RaceId { get; set; }
        public int Position { get; set; }
        public double Points { get; set; } = 0;
        public int? PenaltyPoints { get; set; }
        public Race Race { get; set; }
        public string UserSteamId { get; set; }
        public int BestLap { get; set; }
        public int BestSplit1 { get; set; }
        public int BestSplit2 { get; set; }
        public int BestSplit3 { get; set; }
        public int LapCount { get; set; }

    }
}