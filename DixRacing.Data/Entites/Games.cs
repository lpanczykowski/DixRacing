using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class Games
    {
        public int GameId { get; set; }
        public int Name { get; set; }
        public byte[] Photo { get; set; }
    }
}