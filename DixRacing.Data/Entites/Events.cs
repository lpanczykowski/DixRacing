using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Events
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Games Game { get; set; }
    }
}