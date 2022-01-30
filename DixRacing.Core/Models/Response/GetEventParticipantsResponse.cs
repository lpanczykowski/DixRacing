using DixRacing.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Core.Models.Response
{
    public class GetEventParticipantsResponse
    {
        public ParticipantDto ParticipantDto { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public int Car { get; set; }
    }
}