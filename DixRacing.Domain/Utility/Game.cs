using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Utility
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}