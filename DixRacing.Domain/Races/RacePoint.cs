using DixRacing.Domain.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Races
{
    public class RacePoint : BaseEntity
    {

        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int Position { get; set; }
        public double Points { get; set; }
    }
}