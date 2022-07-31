using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Tracks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Utility
{
    public class Game:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<Track> Tracks { get; set; } 
    }
}