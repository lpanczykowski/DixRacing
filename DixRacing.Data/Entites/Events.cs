using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Games Game { get; set; }
        [ForeignKey("EventId")]
        public ICollection<Rounds> Rounds { get; set; }
        public byte[] Photo { get; set; }
    }
}