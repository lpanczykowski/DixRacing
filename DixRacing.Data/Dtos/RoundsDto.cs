using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Dtos
{
    public class RoundsDto
    {
        public int RoundId { get; set; }
        public int EventId { get; set; }
        public string ServerName { get; set; }
        public string ServerPassword{ get; set; }

        public bool isActive { get; set; }

        
    }

}   