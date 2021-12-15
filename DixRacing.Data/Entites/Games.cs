using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}