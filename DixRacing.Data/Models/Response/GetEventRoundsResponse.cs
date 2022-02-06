using DixRacing.Data.Dtos;
using DixRacing.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Models.Response
{
    public class GetEventRoundsResponse
    {
        public int RoundId { get; set; }
        public int EventId { get; set; }
        public string ServerName { get; set; }
        public string ServerPassword { get; set; }

        public bool isActive { get; set; }


    }

}