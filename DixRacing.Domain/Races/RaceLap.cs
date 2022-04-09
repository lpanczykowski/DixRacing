using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Races
{
    public class RaceLap : BaseEntity
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public string UserSteamId { get; set; }
        public int Lap { get; set; }
        public int Split1 { get; set; }
        public int Split2 { get; set; }
        public int Split3 { get; set; }
        public int IsValid { get; set; }
    }
}