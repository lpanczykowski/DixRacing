using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;

namespace DixRacing.Domain.Tracks
{
    public class Track :BaseEntity
    {
        public byte[] Photo { get; set; }
        public string Name { get; set; }
        public string GameName { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}