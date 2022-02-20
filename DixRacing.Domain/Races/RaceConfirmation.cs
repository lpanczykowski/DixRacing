using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Races
{
    public class RaceConfirmation
    {
        [Key]
        public int RaceConfirmationId { get; set; }
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}