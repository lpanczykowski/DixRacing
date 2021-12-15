using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Tracks
    {
        [Key]
        public int TrackId { get; set; }
        public byte[] Photo { get; set; }
        public string Name { get; set; }
    }
}