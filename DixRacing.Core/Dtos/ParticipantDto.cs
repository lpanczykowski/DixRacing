using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Dtos
{
    public class ParticipantDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}