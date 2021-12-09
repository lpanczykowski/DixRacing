using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class UsersEvents
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Car { get; set; }
        public int Number { get; set; }
        public byte[] Livery { get; set; }
    }
}